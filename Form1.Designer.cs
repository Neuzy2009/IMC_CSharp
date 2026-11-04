namespace IMC_CSharp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.txtPeso = new TextBox();
        this.txtAltura = new TextBox();
        this.btnCalcular = new Button();
        this.lblResultado = new Label();
        this.SuspendLayout();
        // 
        // txtPeso
        // 
        this.txtPeso.Location = new Point(20, 45);
        this.txtPeso.Name = "txtPeso";
        this.txtPeso.Size = new Size(300, 25);
        this.txtPeso.TabIndex = 0;
        // 
        // txtAltura
        // 
        this.txtAltura.Location = new Point(20, 90);
        this.txtAltura.Name = "txtAltura";
        this.txtAltura.Size = new Size(300, 25);
        this.txtAltura.TabIndex = 1;
        // 
        // btnCalcular
        // 
        this.btnCalcular.Location = new Point(20, 140);
        this.btnCalcular.Name = "btnCalcular";
        this.btnCalcular.Size = new Size(340, 45);
        this.btnCalcular.TabIndex = 2;
        this.btnCalcular.Text = "Calcular";
        this.btnCalcular.UseVisualStyleBackColor = true;
        this.btnCalcular.Click += new EventHandler(this.btnCalcular_Click);
        // 
        // lblResultado
        // 
        this.lblResultado.AutoSize = true;
        this.lblResultado.Location = new Point(20, 205);
        this.lblResultado.MinimumSize = new Size(100, 25);
        this.lblResultado.Name = "lblResultado";
        this.lblResultado.Size = new Size(340, 25);
        this.lblResultado.TabIndex = 3;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(400, 280);
        this.Controls.Add(this.lblResultado);
        this.Controls.Add(this.btnCalcular);
        this.Controls.Add(this.txtAltura);
        this.Controls.Add(this.txtPeso);
        this.Name = "Form1";
        this.Text = "Cálculo de IMC";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private TextBox txtPeso;
    private TextBox txtAltura;
    private Button btnCalcular;
    private Label lblResultado;

    #endregion
}
