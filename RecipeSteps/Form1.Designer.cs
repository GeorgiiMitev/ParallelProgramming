namespace RecipeSteps
{
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
            btnStartRecipe = new Button();
            textBoxRecipeOutput = new TextBox();
            SuspendLayout();
            // 
            // btnStartRecipe
            // 
            btnStartRecipe.Location = new Point(369, 390);
            btnStartRecipe.Name = "btnStartRecipe";
            btnStartRecipe.Size = new Size(75, 23);
            btnStartRecipe.TabIndex = 0;
            btnStartRecipe.Text = "Cook";
            btnStartRecipe.UseVisualStyleBackColor = true;
            btnStartRecipe.Click += btnStartRecipe_Click;
            // 
            // textBoxRecipeOutput
            // 
            textBoxRecipeOutput.Location = new Point(11, 9);
            textBoxRecipeOutput.Multiline = true;
            textBoxRecipeOutput.Name = "textBoxRecipeOutput";
            textBoxRecipeOutput.Size = new Size(777, 355);
            textBoxRecipeOutput.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxRecipeOutput);
            Controls.Add(btnStartRecipe);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartRecipe;
        private TextBox textBoxRecipeOutput;
    }
}
