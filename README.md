# sts-contentsupport

Web application to surface additional support for STS services

## Requirements

- .Net 8.0 and any supported IDE for DEV running.


## Running locally

- The startup project is [./src/Dfe.ContentSupport.Web](./src/Dfe.ContentSupport.Web)
- Add 'dotNet-user-secret' to .NET secrets found in keyvault s190d01-cands-kv
- Add yourself with some permissions in the keyvault
  - s190d01-cands-kv/access_policies
- The secrets should be pulled from the keyvault by using them settings. You may need to add your public IP to the firewall on the keyvault
  - s190d01-cands-kv/networking
- Run the application using the http profile
- Go to URL/content/SLUG to test