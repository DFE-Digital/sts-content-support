
######################
# Storage Container #
#######################

variable "tfstate_storage_container_name" {
  type = string
  description = "Storage container to store the tfstate file"

}

variable "tf_state_storage_account"{
  type = string
  description = "Terraform TFstate storage account name"
}

variable "resource_group_name"{
  type = string
  description = "Resource Group name"
}

variable "project_name"{
  type = string
  description = "Project name"
}

variable "environment" {
  type = string
  description  = "Environment name "
}

variable "azure_location" {
  description = "Recourse location"
  type        = string
}

variable "az_tag_environment" {
  description = "Environment tag to be applied to all resources"
  type        = string
}

variable "az_tag_product" {
  description = "Product tag to be applied to all resources"
  type        = string
}


variable "client_id" {
  type = string
  description = "client id"
  default = "value"
}

variable "client_secret" {
  type = string
  description = "client secret"
  default = "value"
}

variable "tenantid"{
  type = string
  description = "Tenant id"
  default = "value"
}

variable "subscriptionid" {
  type = string
  description = "Subscription id "
  default = "value"
}


############
# Identity #
############
variable "msi_id" {
  type        = string
  description = "The Managed Service Identity ID. If this value isn't null (the default), 'data.azurerm_client_config.current.object_id' will be set to this value."
  default     = null
}