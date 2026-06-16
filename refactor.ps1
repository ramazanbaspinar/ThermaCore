$baseDir = "C:\Users\User\source\repos\ThermaCore\ThermaCore.Presentation.WinForms\UserControls"

$files = Get-ChildItem -Path $baseDir -Recurse -Filter *.cs

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw

    # Namespace replacements
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Model\.Entities\.Base;", "using ThermaCore.Domain.Entities.Base;"
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Model\.Entities\.Base\.Interfaces;", "using ThermaCore.Domain.Entities.Base.Interfaces;"
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Bll\.Interfaces;", "using ThermaCore.Application.Interfaces.Base;"
    $content = $content -replace "using RbaYazilim\.WinRezistans\.UI\.Win\.Interfaces;", "using ThermaCore.Presentation.WinForms.Interfaces;"
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Common\.Message;", "using ThermaCore.Presentation.WinForms.Helpers;"
    $content = $content -replace "using RbaYazilim\.WinRezistans\.UI\.Win\.BaseForms\.Forms;", "using ThermaCore.Presentation.WinForms.Forms.BaseForms;"
    $content = $content -replace "using RbaYazilim\.WinRezistans\.UI\.Win\.Functions;", "using ThermaCore.Presentation.WinForms.Helpers;"
    
    # Remove unused BLL
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Bll\.Functions;\r?\n", ""
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Bll;\r?\n", ""
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Common;\r?\n", ""
    $content = $content -replace "using RbaYazilim\.WinRezistans\.Model;\r?\n", ""
    $content = $content -replace "using RbaYazilim\.WinRezistans\.UI\.Win\.Forms;\r?\n", ""
    $content = $content -replace "using RbaYazilim\.WinRezistans\.UI\.Win\.Show;\r?\n", ""

    # Class / Method replacements
    $content = $content -replace "namespace RbaYazilim\.WinRezistans\.UI\.Win\.UserControls", "namespace ThermaCore.Presentation.WinForms.UserControls"
    $content = $content -replace "IBaseHareketGenelBll", "IBaseHareketService"
    $content = $content -replace "IBaseBll", "IBaseService"
    $content = $content -replace "\.RefreshDataSource\(\)", ".RefreshData()"
    $content = $content -replace "\(\(IStatusBarKisaYol\)sender\)", "((IStatusBarKisaYol)(sender ?? this))"
    $content = $content -replace "\(object sender", "(object? sender"
    
    # Pragma for CS8618
    if ($content -notmatch "#pragma warning disable CS8618") {
        $content = "#pragma warning disable CS8618`r`n" + $content
    }

    Set-Content -Path $file.FullName -Value $content -Encoding UTF8
}

Write-Host "Migration complete."
