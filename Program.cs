using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
 
namespace CalculadoraIMC
{
    public class FormIMC : Form
    {
        private Label lblTitulo;
        private Label lblPeso;
        private Label lblAltura;
        private TextBox txtPeso;
        private TextBox txtAltura;
        private Button btnCalcular;
        private Label lblResultado;
        private Label lblDica;
        private Panel pnlRodape;
        private Label lblRodape;
 
        public FormIMC()
        {
            InicializarComponentes();
        }
 
        private void InicializarComponentes()
        {
            Text = "Calculadora de IMC";
            ClientSize = new Size(800, 470);
            MinimumSize = new Size(816, 509);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(243, 243, 243);
 
            Color azulTitulo = Color.FromArgb(0, 114, 188);
            Color azulBotao = Color.FromArgb(40, 140, 200);
 
            // Título
            lblTitulo = new Label
            {
                Text = "Calculadora de IMC",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = azulTitulo,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Location = new Point(0, 20),
                Size = new Size(800, 70),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
 
            // Peso
            lblPeso = new Label
            {
                Text = "Peso (kg):",
                Font = new Font("Segoe UI", 14F),
                Location = new Point(170, 105),
                AutoSize = true
            };
 
            txtPeso = new TextBox
            {
                Name = "txtPeso",
                Font = new Font("Segoe UI", 14F),
                PlaceholderText = "Digite o seu peso...",
                Location = new Point(170, 142),
                Width = 460
            };
 
            // Altura
            lblAltura = new Label
            {
                Text = "Altura (m):",
                Font = new Font("Segoe UI", 14F),
                Location = new Point(170, 192),
                AutoSize = true
            };
 
            txtAltura = new TextBox
            {
                Name = "txtAltura",
                Font = new Font("Segoe UI", 14F),
                PlaceholderText = "Digite a sua altura (ex: 1.75)...",
                Location = new Point(170, 229),
                Width = 460
            };
 
            // Botão
            btnCalcular = new Button
            {
                Name = "btnCalcular",
                Text = "Calcular IMC",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = azulBotao,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(170, 300),
                Size = new Size(230, 95),
                Cursor = Cursors.Hand
            };
            btnCalcular.FlatAppearance.BorderColor = Color.FromArgb(30, 110, 170);
            btnCalcular.Click += btnCalcular_Click;
 
            // Resultado
            lblResultado = new Label
            {
                Name = "lblResultado",
                Text = "Resultado do IMC e Classificação aparecerão aqui.",
                Font = new Font("Segoe UI", 10.5F),
                Location = new Point(415, 300),
                Size = new Size(215, 60),
                AutoSize = false
            };
 
            // Dica
            lblDica = new Label
            {
                Text = "*Use ponto para decimais (ex: 1.75, 75.5)*",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(415, 370),
                Size = new Size(215, 40),
                AutoSize = false
            };
 
            // Rodapé
            pnlRodape = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.FromArgb(205, 205, 205)
            };
 
            lblRodape = new Label
            {
                Text = "Desenvolvido por: Neusio Julio Langa\n2026",
                Font = new Font("Segoe UI", 8.5F),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            pnlRodape.Controls.Add(lblRodape);
 
            AcceptButton = btnCalcular;
            Controls.AddRange(new Control[]
            {
                lblTitulo, lblPeso, txtPeso, lblAltura, txtAltura,
                btnCalcular, lblResultado, lblDica, pnlRodape
            });
        }
 
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Aceita tanto vírgula como ponto como separador decimal
            string pesoTexto = txtPeso.Text.Trim().Replace(',', '.');
            string alturaTexto = txtAltura.Text.Trim().Replace(',', '.');
 
            // Conversão segura com TryParse (cultura invariante)
            bool pesoValido = double.TryParse(pesoTexto, NumberStyles.Float, CultureInfo.InvariantCulture, out double peso);
            bool alturaValida = double.TryParse(alturaTexto, NumberStyles.Float, CultureInfo.InvariantCulture, out double altura);
 
            if (!pesoValido || !alturaValida)
            {
                lblResultado.ForeColor = Color.Firebrick;
                lblResultado.Text = "Introduza apenas valores numéricos no peso e na altura.";
                return;
            }
 
            if (peso <= 0 || altura <= 0)
            {
                lblResultado.ForeColor = Color.Firebrick;
                lblResultado.Text = "O peso e a altura têm de ser superiores a zero.";
                return;
            }
 
            // Fórmula padrão: IMC = peso / altura²
            double imc = peso / (altura * altura);
 
            lblResultado.ForeColor = Color.Black;
            lblResultado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblResultado.Text = $"IMC: {imc:F2}\nClassificação: {Classificar(imc)}";
        }
 
        private static string Classificar(double imc)
        {
            if (imc < 18.5) return "Abaixo do peso";
            if (imc < 25.0) return "Peso normal";
            if (imc < 30.0) return "Excesso de peso";
            if (imc < 35.0) return "Obesidade grau I";
            if (imc < 40.0) return "Obesidade grau II";
            return "Obesidade grau III";
        }
    }
 
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormIMC());
        }
    }
}
 
