using System;
using k8s;
using System.IO;

namespace dotnetapp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // DirectoryInfo files= new DirectoryInfo("/config");
            // Console.WriteLine("File details:");
            // foreach(FileInfo fi in files.GetFiles()){
            //     Console.WriteLine(fi.FullName);
            // }

            Console.WriteLine(" doing k8s stuff");
            // Load from in-cluster configuration:
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile(Environment.GetEnvironmentVariable("KUBECONFIG"));

            var client = new Kubernetes(config);

            k8s.Models.V1PodList plist = client.CoreV1.ListNamespacedPod("xmrig");
            foreach(var items in plist.Items){

                if(items.Metadata.Name.Substring(0,5)=="xmrig"){
                    client.CoreV1.DeleteNamespacedPod(items.Metadata.Name,"xmrig");
                }
            }

        }
    }
}