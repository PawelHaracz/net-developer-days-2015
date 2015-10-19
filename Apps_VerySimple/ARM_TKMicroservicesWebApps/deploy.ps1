Select-AzureSubscription DEMOTEST
Switch-AzureMode -Name AzureResourceManager
New-AzureResourceGroup -Name rgExampleMicroserviceGroup -Location "West Europe"
New-AzureResourceGroupDeployment -Name ExampleDeployment -ResourceGroupName rgExampleMicroserviceGroup `
-TemplateFile "C:\AzureFY15TK\07 Resource Manager\TKMicroservicesWebApps\azuredeploy.json" `
-siteLocation "West Europe"