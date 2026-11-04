using System.Globalization;

namespace IMC_CSharp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnCalcular_Click(object sender, EventArgs e)
    {
        // Conversão segura: só calcula se ambos os valores forem numéricos e válidos.
        if (double.TryParse(txtPeso.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double peso) &&
            double.TryParse(txtAltura.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double altura) &&
            peso > 0 && altura > 0)
        {
            double imc = CalcularImc(peso, altura);
            lblResultado.Text = $"IMC: {imc:F2} — {ClassificarImc(imc)}";
        }
        else
        {
            lblResultado.Text = "Por favor, insira valores válidos.";
        }
    }

    private double CalcularImc(double peso, double altura)
    {
        return peso / (altura * altura);
    }

    private string ClassificarImc(double imc)
    {
        return imc switch
        {
            < 18.5 => "Abaixo do peso",
            < 25 => "Peso normal",
            < 30 => "Sobrepeso",
            < 35 => "Obesidade Grau I",
            < 40 => "Obesidade Grau II",
            _ => "Obesidade Grau III",
        };
    }
}
