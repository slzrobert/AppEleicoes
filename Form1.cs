using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEleicoes
{
    public partial class Form1 : Form
    {
        List<Arquivo> arquivos = new List<Arquivo>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void EnviarArquivosAsync()
        {
            string caminho;

            caminho = @"C:\Users\Robert\Desktop\Documentos\Imagens";

            for (int i = 0; i < arquivos.Count; i++)
            {
                int percentual = (int)((double)(i + 1) / (double)arquivos.Count * 100.0);
                string arquivo = caminho + @"\" + arquivos[i].nome;

                FileInfo file = new FileInfo(arquivo);

                listView1.Items[i].ForeColor = Color.Blue;
                listView1.Items[i].SubItems[2].Text = "Enviando...";
                listView1.Items[i].SubItems[3].Text = "Enviando arquivo file" + i + file.Extension + ".";

                FTP ftp = new FTP();
                ftp.UploadProgress += Ftp_UploadProgress;

                int upCompleted = await Task.Run(() => ftp.Upload(arquivo, i));

                if (upCompleted == 0)
                {
                    arquivos[i].erro = true;

                    listView1.Items[i].ForeColor = Color.Red;
                    listView1.Items[i].SubItems[2].Text = "Erro";
                    listView1.Items[i].SubItems[3].Text = "Erro ao processar envio.";
                }
                else
                {
                    arquivos[i].erro = false;

                    listView1.Items[i].ForeColor = Color.Green;
                    listView1.Items[i].SubItems[2].Text = "Enviado";
                    listView1.Items[i].SubItems[3].Text = "Arquivo file" + i + file.Extension + " enviado.";
                }

                await Task.Run(() =>
                {
                    if (InvokeRequired)
                    {
                        _ = Invoke((MethodInvoker)delegate
                        {
                            lblFilesToSend.Text = percentual.ToString() + "%";
                            barraProgresso.Value = percentual;
                        });
                    }
                    else
                    {
                        lblFilesToSend.Text = percentual.ToString() + "%";
                        barraProgresso.Value = percentual;
                    }
                });
            }

            MessageBox.Show("Processo finalizado.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BuscarDados(true);
        }

        private void Ftp_UploadProgress(object sender, UploadProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                _ = Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = e.percent;
                    lblFileSend.Text = e.percent.ToString() + "%";
                });
            }
            else
            {
                progressBar1.Value = e.percent;
                lblFileSend.Text = e.percent.ToString() + "%";
            }
        }

        private void BuscarDados(bool atualizando = false)
        {
            listView1.Clear();
            listView1.GridLines = true;

            listView1.Columns.Add("Arquivo", 250);
            listView1.Columns.Add("Data Modificação", 150, HorizontalAlignment.Right);
            listView1.Columns.Add("Status", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Mensagem", 300);

            if (atualizando == false)
            {
                if (arquivos.Count > 0)
                    arquivos.Clear();

                for (int i = 0; i < 6; i++)
                {

                    //arquivos.Add("teste.json");

                    arquivos.Add(new Arquivo
                    {
                        nome = "teste.json",
                        tamanho = 562548,
                        erro = false
                    });

                    ListViewItem Item = new ListViewItem(new[] {
                        "teste.json",
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        "Fila de Envio",
                        ""
                    }, -1);

                    listView1.Items.Add(Item);
                }
            } else
            {

                List<Arquivo> files = arquivos.Where(x => x.erro == true).ToList();

                files.ForEach(delegate(Arquivo arquivo)
                {
                    ListViewItem Item = new ListViewItem(new[] {
                        arquivo.nome,
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        "Fila de Envio",
                        ""
                    }, -1);

                    listView1.Items.Add(Item);
                });

                arquivos = files;
            }

            if(arquivos.Count > 0)
                BtnEnviar.Enabled = true;

            barraProgresso.Value = 0;
            progressBar1.Value = 0;

            lblFileSend.Text = "0%";
            lblFilesToSend.Text = "0%";
        }

        private void IniciaEnvio()
        {
            EnviarArquivosAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuscarDados();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            BtnEnviar.Enabled = false;
            IniciaEnvio();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int idx = listView1.SelectedIndices[0];

            MessageBox.Show(idx.ToString());            

            arquivos.Remove(arquivos[idx]);
            listView1.Items.Remove(listView1.Items[idx]);

            

        }
    }
}
