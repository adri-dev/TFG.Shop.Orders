provider "azurerm" {
  features {}

  skip_provider_registration = true
}
data "azurerm_kubernetes_cluster" "example" {
  name                = var.cluster_name
  resource_group_name = var.resource_group_name
}

provider "kubernetes" {
  host                   = data.azurerm_kubernetes_cluster.example.kube_config.0.host
  client_certificate     = base64decode(data.azurerm_kubernetes_cluster.example.kube_config.0.client_certificate)
  client_key             = base64decode(data.azurerm_kubernetes_cluster.example.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(data.azurerm_kubernetes_cluster.example.kube_config.0.cluster_ca_certificate)
}

resource "kubernetes_deployment_v1" "deployment" {
  metadata {
    name = "orders-dply"
  }

  spec {
    selector {
      match_labels = {
        app   = "orders"
        tier  = "backend"
        track = "stable"
      }
    }

    replicas = 1

    template {
      metadata {
        labels = {
          app   = "orders"
          tier  = "backend"
          track = "stable"
        }
      }

      spec {
        container {
          name  = "orders"
          image = "docker.io/wadrydev/tfgorders"
          env {
            name  = "ConnectionStrings__OrdersDb"
            value = "XX"
          }
          port {
            name           = "http"
            container_port = 80
          }
        }
      }
    }
  }
}

resource "kubernetes_service" "svc" {
  metadata {
    name = "orders"
  }
  spec {
    selector = {
      app  = "orders"
      tier = "backend"
    }
    port {
      protocol    = "TCP"
      port        = 80
      target_port = "http"
    }
  }
}
