namespace criptografia_csharp
{
    partial class frmCriptografiaOpenSSL
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
            label1 = new Label();
            txtPlainText = new TextBox();
            btnCriptografiarOpenSSL = new Button();
            label2 = new Label();
            txtTextoCriptografado = new TextBox();
            btnDescriptografar = new Button();
            btnCopiarCripto = new Button();
            label3 = new Label();
            txtPassphrase = new TextBox();
            label4 = new Label();
            txtSalt = new TextBox();
            btnCopiarPlain = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 0;
            label1.Text = "Plain Text";
            // 
            // txtPlainText
            // 
            txtPlainText.Location = new Point(12, 37);
            txtPlainText.Multiline = true;
            txtPlainText.Name = "txtPlainText";
            txtPlainText.ScrollBars = ScrollBars.Vertical;
            txtPlainText.Size = new Size(1194, 289);
            txtPlainText.TabIndex = 1;
            // 
            // btnCriptografiarOpenSSL
            // 
            btnCriptografiarOpenSSL.Location = new Point(1045, 332);
            btnCriptografiarOpenSSL.Name = "btnCriptografiarOpenSSL";
            btnCriptografiarOpenSSL.Size = new Size(161, 47);
            btnCriptografiarOpenSSL.TabIndex = 2;
            btnCriptografiarOpenSSL.Text = "&Criptografar";
            btnCriptografiarOpenSSL.UseVisualStyleBackColor = true;
            btnCriptografiarOpenSSL.Click += btnCriptografiarOpenSSL_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 354);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 3;
            label2.Text = "Criptografado";
            // 
            // txtTextoCriptografado
            // 
            txtTextoCriptografado.Location = new Point(12, 400);
            txtTextoCriptografado.Multiline = true;
            txtTextoCriptografado.Name = "txtTextoCriptografado";
            txtTextoCriptografado.ScrollBars = ScrollBars.Vertical;
            txtTextoCriptografado.Size = new Size(1194, 289);
            txtTextoCriptografado.TabIndex = 4;
            // 
            // btnDescriptografar
            // 
            btnDescriptografar.Location = new Point(1045, 695);
            btnDescriptografar.Name = "btnDescriptografar";
            btnDescriptografar.Size = new Size(161, 47);
            btnDescriptografar.TabIndex = 5;
            btnDescriptografar.Text = "&DesCriptografar";
            btnDescriptografar.UseVisualStyleBackColor = true;
            btnDescriptografar.Click += btnDescriptografar_Click;
            // 
            // btnCopiarCripto
            // 
            btnCopiarCripto.Location = new Point(878, 695);
            btnCopiarCripto.Name = "btnCopiarCripto";
            btnCopiarCripto.Size = new Size(161, 47);
            btnCopiarCripto.TabIndex = 6;
            btnCopiarCripto.Text = "Copiar";
            btnCopiarCripto.UseVisualStyleBackColor = true;
            btnCopiarCripto.Click += btnCopiarCripto_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 717);
            label3.Name = "label3";
            label3.Size = new Size(101, 25);
            label3.TabIndex = 7;
            label3.Text = "passphrase";
            // 
            // txtPassphrase
            // 
            txtPassphrase.Location = new Point(119, 717);
            txtPassphrase.Name = "txtPassphrase";
            txtPassphrase.Size = new Size(168, 31);
            txtPassphrase.TabIndex = 8;
            txtPassphrase.Text = "qwerty";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(304, 723);
            label4.Name = "label4";
            label4.Size = new Size(39, 25);
            label4.TabIndex = 9;
            label4.Text = "salt";
            // 
            // txtSalt
            // 
            txtSalt.Location = new Point(349, 720);
            txtSalt.Name = "txtSalt";
            txtSalt.Size = new Size(168, 31);
            txtSalt.TabIndex = 10;
            txtSalt.Text = "241fa86763b85341";
            // 
            // btnCopiarPlain
            // 
            btnCopiarPlain.Location = new Point(878, 332);
            btnCopiarPlain.Name = "btnCopiarPlain";
            btnCopiarPlain.Size = new Size(161, 47);
            btnCopiarPlain.TabIndex = 11;
            btnCopiarPlain.Text = "Copiar";
            btnCopiarPlain.UseVisualStyleBackColor = true;
            btnCopiarPlain.Click += btnCopiarPlain_Click;
            // 
            // frmCriptografiaOpenSSL
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 771);
            Controls.Add(btnCopiarPlain);
            Controls.Add(txtSalt);
            Controls.Add(label4);
            Controls.Add(txtPassphrase);
            Controls.Add(label3);
            Controls.Add(btnCopiarCripto);
            Controls.Add(btnDescriptografar);
            Controls.Add(txtTextoCriptografado);
            Controls.Add(label2);
            Controls.Add(btnCriptografiarOpenSSL);
            Controls.Add(txtPlainText);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmCriptografiaOpenSSL";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criptografia OpenSSL";
            Load += frmCriptografiaOpenSSL_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlainText;
        private Button btnCriptografiarOpenSSL;
        private Label label2;
        private TextBox txtTextoCriptografado;
        private Button btnDescriptografar;
        private Button btnCopiarCripto;
        private Label label3;
        private TextBox txtPassphrase;
        private Label label4;
        private TextBox txtSalt;
        private Button btnCopiarPlain;
    }
}
