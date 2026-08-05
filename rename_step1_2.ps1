$ErrorActionPreference = "Stop"
$oldName = "ThermaCore"
$newName = "WinBeyazEsya"
$dir = "c:\Users\User\source\repos\ThermaCore"

Write-Host "Updating solution files..."
Get-ChildItem -Path $dir -Filter "*$oldName*.sln*" -File | ForEach-Object {
    $content = Get-Content -Path $_.FullName -Raw -Encoding UTF8
    $content = $content.Replace($oldName, $newName)
    Set-Content -Path $_.FullName -Value $content -Encoding UTF8
    Rename-Item -Path $_.FullName -NewName ($_.Name.Replace($oldName, $newName))
    Write-Host "Renamed and updated $($_.Name)"
}

Write-Host "Updating csproj files..."
Get-ChildItem -Path $dir -Filter "*$oldName*.csproj*" -Recurse -File | ForEach-Object {
    $content = Get-Content -Path $_.FullName -Raw -Encoding UTF8
    $content = $content.Replace($oldName, $newName)
    Set-Content -Path $_.FullName -Value $content -Encoding UTF8
    Rename-Item -Path $_.FullName -NewName ($_.Name.Replace($oldName, $newName))
    Write-Host "Renamed and updated $($_.Name)"
}

Write-Host "Renaming directories..."
$directories = Get-ChildItem -Path $dir -Filter "*$oldName*" -Directory -Recurse | Where-Object { $_.FullName -ne $dir } | Sort-Object -Property @{Expression={$_.FullName.Length}; Descending=$true}
foreach ($d in $directories) {
    Rename-Item -Path $d.FullName -NewName ($d.Name.Replace($oldName, $newName))
    Write-Host "Renamed directory $($d.Name)"
}

Write-Host "Step 1 and 2 completed successfully."
