$replacements = [ordered]@{
    'Ã¼' = 'ü'
    'Ä±' = 'ı'
    'ÄŸ' = 'ğ'
    'Ã§' = 'ç'
    'ÅŸ' = 'ş'
    'Ã¶' = 'ö'
    'Ãœ' = 'Ü'
    'Ä°' = 'İ'
    'Äž' = 'Ğ'
    'Ã‡' = 'Ç'
    'Åž' = 'Ş'
    'Ã–' = 'Ö'
}

$files = Get-ChildItem -Path "c:\Users\User\source\repos\ThermaCore" -Include *.cs,*.resx,*.json -Recurse

foreach ($file in $files) {
    $content = [System.IO.File]::ReadAllText($file.FullName, [System.Text.Encoding]::UTF8)
    $modified = $false
    foreach ($key in $replacements.Keys) {
        if ($content.Contains($key)) {
            $content = $content.Replace($key, $replacements[$key])
            $modified = $true
        }
    }
    if ($modified) {
        Write-Host "Modified: $($file.FullName)"
        $utf8bom = New-Object System.Text.UTF8Encoding $true
        [System.IO.File]::WriteAllText($file.FullName, $content, $utf8bom)
    }
}
