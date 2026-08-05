$ErrorActionPreference = "Stop"

Add-Type -Path "c:\Users\User\source\repos\ThermaCore\WinBeyazEsya.Infrastructure\bin\Debug\net8.0\WinBeyazEsya.Infrastructure.dll"
$crypto = New-Object WinBeyazEsya.Infrastructure.Security.CryptoService
$json = Get-Content "$env:LOCALAPPDATA\WinBeyazEsya\settings.json" | ConvertFrom-Json
$connStr = $crypto.Decrypt($json.ConnectionString)

Write-Host "Decrypted Connection String: $connStr"

$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "UPDATE TenantDatabases SET AuthType = 1, Username = '', Password = '';"
$rows = $cmd.ExecuteNonQuery()
Write-Host "Fixed $rows tenant(s) to use Windows Authentication."

$conn.Close()
