using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

namespace Tools
{
    public class CsvDownloader : MonoBehaviour
    {
        public TMP_Text downloadedDataText;
        
        public void DownloadCSV()
        {
            string csvUrl =
                "https://docs.google.com/spreadsheets/d/1rVrNGJ8ZATl9vFnmHZEY6t7cl-hkmu8z3HHhf9bD00U/export?format=csv";
            
            StartCoroutine(DownloadCSVCoroutine(csvUrl));
        }
        
        
        private IEnumerator DownloadCSVCoroutine(string url)
        {
            UnityWebRequest www = new UnityWebRequest(url);
            yield return www; // Esperar a que se complete la descarga

            // Verificar si hubo un error en la descarga
            if (www.error != null)
            {
                Debug.LogError("Error downloading CSV: " + www.error);
                yield break; // Salir de la corrutina si hay un error
            }
            
            string csvData = www.ToString();
            List<Register> registers = ParseCSV(csvData);
            DisplayCSVData(registers);
            
            Debug.Log(www.ToString());
        }


        private List<Register> ParseCSV(string csvData)
        {
            List<Register> registers = new List<Register>();

            string[] lines = csvData.Split('\n');

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] values = line.Split(',');

                if (values.Length != 3)
                    continue;

                RegisterType type;
                string comment;
                int value;

                try
                {
                    type = (RegisterType)Enum.Parse(typeof(RegisterType), values[0]);
                    comment = values[1];
                    value = int.Parse(values[2]);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error parsing CSV line: " + e.Message);
                    continue;
                }
                
                Register register = new Register(type, comment, value);
                registers.Add(register);
            }

            return registers;
        }
        
        
        private void DisplayCSVData(List<Register> registers)
        {
            string displayText = "Downloaded Data: ";

            foreach (Register register in registers)
            {
                displayText += register.GetContent();
            }
            
            
            downloadedDataText.text = displayText;
            Debug.Log(downloadedDataText.text);
        }
    }
}
