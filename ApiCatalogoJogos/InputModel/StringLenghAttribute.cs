using System;

namespace ApiCatalogoLivros.InputModel
{
    internal class StringLenghAttribute : Attribute
    {
        public StringLenghAttribute(int v, int MinimumLengh, string ErrorMessage)
        {
            V = v;
            this.MinimumLengh = MinimumLengh;
            this.ErrorMessage = ErrorMessage;
        }

        public int V { get; }
        public int MinimumLengh { get; }
        public string ErrorMessage { get; }
    }
}