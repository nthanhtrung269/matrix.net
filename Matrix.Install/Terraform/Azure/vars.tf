variable "environment" {
    description = "environment name"
    type        = "string"
    default     = "prod"
}

variable "configuration" {
    description = "configuration flag"
    type        = "string"
    default     = "debug"
}

variable "region" {
    description = "geographic region"
    type        = "string"
    default     = "WestUS2"
}

variable "resource_group" {
    description = "resource group name"
    type        = "string"
    default     = "matrix"
}

variable "network_address" {
    description = "virtual network address space"
    type        = "string"
    default     = "10.1.0.0/16"
}

variable "network_subnet" {
    description = "network subnet address space"
    type        = "string"
    default     = "10.1.1.0/24"
}

variable "hostname" {
    description = "node hostname"
    type        = "string"
    default     = "matrix-node"
}

variable "scale" {
    description = "scalability factor"
    type        = "string"
    default     = "1"
}

variable "whitelist" {
    description = "whitelist ip address"
    type        = "string"
    default     = "*"
}