using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Printing;

namespace LimpaImpressora
{
    public partial class Form1 : Form
    {
        // Criar uma tabela para armazenar as informações das impressoras
        DataTable printerTable = new DataTable();

        public Form1()
        {
            InitializeComponent();

            printerTable.Columns.Add("Nome da Impressora", typeof(string));
            printerTable.Columns.Add("Status", typeof(string));
            printerTable.Columns.Add("Trabalhos de Impressão", typeof(int));

            // Obter o servidor de impressão local
            LocalPrintServer printServer = new LocalPrintServer();

            // Obter uma lista de todas as filas de impressão
            PrintQueueCollection printQueues = printServer.GetPrintQueues();

            // Percorrer a lista de filas de impressão e adicionar as informações à tabela
            foreach (PrintQueue printQueue in printQueues)
            {
                DataRow row = printerTable.NewRow();
                row["Nome da Impressora"] = printQueue.Name;
                row["Status"] = printQueue.QueueStatus.ToString();
                row["Trabalhos de Impressão"] = printQueue.NumberOfJobs;
                printerTable.Rows.Add(row);
            }

            // Definir o DataSource do DataGridView como a tabela criada
            dataGridView1.DataSource = printerTable;
        }
    }
}