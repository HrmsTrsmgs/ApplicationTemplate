param(
    # Start directory (optional). If omitted, current directory is used.
    [string]$StartDirectory
)

if ([string]::IsNullOrWhiteSpace($StartDirectory)) {
    $StartDirectory = (Get-Location).Path
}

function Get-RelativePath {
    param(
        [Parameter(Mandatory = $true)]
        [string]$BasePath,
        [Parameter(Mandatory = $true)]
        [string]$Path
    )

    $baseFull = (Resolve-Path $BasePath).ProviderPath
    if (-not $baseFull.EndsWith('\')) {
        $baseFull += '\'
    }

    $pathFull = (Resolve-Path $Path).ProviderPath

    $uriBase = [Uri]$baseFull
    $uriPath = [Uri]$pathFull

    $relativeUri  = $uriBase.MakeRelativeUri($uriPath)
    $relativePath = [Uri]::UnescapeDataString($relativeUri.ToString())

    # Normalize to Windows-style path
    return ($relativePath -replace '/', '\')
}

# 1) Walk up from StartDirectory to find *.sln
$dir = (Resolve-Path $StartDirectory).ProviderPath
$solutionDir = $null
$solutionFile = $null

while ($true) {
    $sln = Get-ChildItem -Path $dir -Filter *.sln -File -ErrorAction SilentlyContinue
    if ($sln) {
        $solutionDir = $dir
        $solutionFile = $sln | Select-Object -First 1
        break
    }

    $parent = Split-Path $dir -Parent
    if (-not $parent -or $parent -eq $dir) {
        throw "Solution file (*.sln) not found. StartDirectory: $StartDirectory"
    }

    $dir = $parent
}

Write-Host "Solution folder: $solutionDir"
Write-Host "Solution file  : $($solutionFile.Name)"

# 2) Find .cs / .xaml under solution folder, excluding bin/obj and generated files
$files = Get-ChildItem -Path $solutionDir -Recurse -File |
    Where-Object {
        ($_.Extension -in '.cs', '.xaml') -and
        ($_.FullName -notmatch '\\(bin|obj)\\') -and
        -not ($_.Name -match '\.(g|g\.i|designer|generated)\.cs$')
    } |
    Sort-Object FullName

if (-not $files -or $files.Count -eq 0) {
    throw "No .cs or .xaml files found."
}

# 3) Build markdown code blocks
$sb = [System.Text.StringBuilder]::new()
$ticks = [string]([char]96) * 3   # "```"

foreach ($file in $files) {
    $relative = Get-RelativePath -BasePath $solutionDir -Path $file.FullName
    $lang = if ($file.Extension -eq '.xaml') { 'xml' } else { 'csharp' }

    # header line: ```csharp title=path\to\File.cs
    $headerLine = "$ticks$lang title=$relative"
    [void]$sb.AppendLine($headerLine)

    $content = Get-Content -LiteralPath $file.FullName -Raw
    [void]$sb.AppendLine($content)

    # closing ``` and blank line
    [void]$sb.AppendLine($ticks)
    [void]$sb.AppendLine()
}

# 4) Copy to clipboard
$allText = $sb.ToString()
Set-Clipboard -Value $allText

Write-Host "$($files.Count) files copied to clipboard as markdown code blocks."
