#pragma once

class PC2
{
public:
	CPU cm;
	RAM ram;
	HDD hdd;
	Motherboard mb;

	PC2() {}
	PC2(wchar_t* cpuname, double cpuf, int ramv, int hddv, wchar_t* mbname)
	{
		CPU cp(cpuname, cpuf);
		RAM rm(ramv);
		HDD hd(hddv);
		Motherboard mb(mbname);
		this->cm = cp;
		this->ram = rm;
		this->hdd = hd;
		this->mb = mb;
	}
	friend wostream& operator<<(wostream& os, const PC2 pc)
	{
		os << *pc.cm << endl;
		os << *pc.ram << endl;
		os << *pc.hdd << endl;
		os << *pc.mb << endl;
		return os;
	}
};