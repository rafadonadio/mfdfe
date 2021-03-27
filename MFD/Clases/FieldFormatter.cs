using System;

namespace MFD.Clases {
    class FieldFormatter {
        private FieldFormatter(){}

        private static FieldFormatter instance = null;
        public static FieldFormatter Instance {
            get {
                if(instance==null) instance=new FieldFormatter();
                return instance;
            }
        }

        public string FormatDate(DateTime? fecha) {
            if (fecha != null) return FormatDate(fecha.Value);
            else return "        ";
        }

        public string FormatDate(DateTime fecha) {
            return String.Format("{0:yyyyMMdd}", fecha);
        }

        public string FormatInt(int number) {
            return FormatInt(number, 8);
        }

        public string FormatInt(int number, int length) {
            return FormatDouble(number, length, 0);
        }

        public string FormatDouble(double number) {
            return FormatDouble(number, 15);
        }

        public string FormatDouble(double number, int length) {
            return FormatDouble(number, length, 2);
        }

        public string FormatDouble(double number, int length, int precision) {
            string formatter = String.Empty.PadLeft(length - precision, '0') + "." + String.Empty.PadLeft(precision, '0');
            return number.ToString(formatter).Replace(".", "").Replace(",", "");
        }
        
        public string Spaces(int length) {
            return String.Empty.PadLeft(length);
        }
        
        public string Zeros(int length) {
            return String.Empty.PadLeft(length,'0');
        }
    }
}
