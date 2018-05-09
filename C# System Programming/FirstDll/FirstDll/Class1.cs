using System;

namespace FirstDll
{
    public class Auto
    {
		private String marka;
		private String model;
		private int year;

		public Auto(String marka, String model, int year)
		{
			this.marka = marka;
			this.model = model;
			this.year = year;
		}

		public override string ToString()
		{
			return String.Format("Марка: {0}, Модель: {1}, Год: {2}", this.marka, this.model, this.year);
		}
	}
}
