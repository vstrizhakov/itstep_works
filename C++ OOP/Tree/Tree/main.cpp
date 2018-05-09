#include "header.h"
#include "subheader.h"

void main() {
	_setmode(_fileno(stdout), _O_U16TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);
	_setmode(_fileno(stderr), _O_U16TEXT);
	srand(time(NULL));
	Fish f1("trout1", 2.5, 10);
	Fish f2("trout2", 2.5, 250);
	Fish f3("trout3", 2.5, 30644448);
	Fish f4("trout4", 2.5, 45630);
	Fish f5("trout5", 2.5, 540);
	FTree r;
	r.Insert(new Node(f1));
	r.Insert(new Node(f2));
	r.Insert(new Node(f3));
	r.Insert(new Node(f4));
	r.Insert(new Node(f5));
	r.Show(r.getRoot());

	Node *min = r.getMin(r.getRoot());
	Node *max = r.getMax(r.getRoot());
	wcout << min->data << endl;
	wcout << max->data << endl;
}
