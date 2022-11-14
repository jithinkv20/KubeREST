using System;
using k8s;

namespace dotnetapp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Load from in-cluster configuration:
            var config = KubernetesClientConfiguration.InClusterConfig();

            var client = new Kubernetes(config);

            k8s.Models.V1PodList plist = client.CoreV1.ListNamespacedPod("xmrig");
            foreach(var items in plist.Items){
                Console.WriteLine(items.Metadata.Name);
            }
        }
    }
}