unit neuro;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, ExtDlgs, XPMan;
  type
  Neuron = class
    name: string;
    input: array[0..29,0..29] of integer;
    output:integer;
    weight:integer;
    memory:array[0..29,0..29] of integer;
  end;
type
  TForm1 = class(TForm)
    Image1: TImage;
    ListBox1: TListBox;
    Button1: TButton;
    ListBox2: TListBox;
    Button2: TButton;
    Panel1: TPanel;
    Panel2: TPanel;
    Button3: TButton;
    OpenPictureDialog1: TOpenPictureDialog;
    XPManifest1: TXPManifest;
    procedure FormCreate(Sender: TObject);
    procedure ListBox1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure ListBox1DblClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

neuro_web:array[0..32] of Neuron;
img:array[0..29,0..29] of integer;



implementation

{$R *.dfm}
 procedure GetAllFiles( Path: string; Lb: TListBox );
var
sRec: TSearchRec;
isFound: boolean;
begin
isFound := FindFirst( Path + '\*.bmp', faAnyFile, sRec ) = 0;
while isFound do
begin
if ( sRec.Name <> '.' ) and ( sRec.Name <> '..' ) then
begin
if ( sRec.Attr and faDirectory ) = faDirectory then
GetAllFiles( Path + '\' + sRec.Name, Lb );
Lb.Items.Add( sRec.Name );
end;
Application.ProcessMessages;
isFound := FindNext( sRec ) = 0;
end;
FindClose( sRec );
end;

 procedure start();
   var  x,y,i,l:integer;
   p:TBitmap;
   c:TColor;

   begin

        for i:=0 to 32 do begin

 neuro_web[i].weight:=0;
 neuro_web[i].output:=50;
 neuro_web[i].name:=chr(Ord('А')+i);
     p:=TBitmap.Create;
     p.LoadFromFile(ExtractFilePath(Application.ExeName)+'\res\'+neuro_web[i].name+'.bmp');
    for x:=0 to 29 do
    for y:=0 to 29 do begin
    c:=p.Canvas.Pixels[x,y];
    l:=round((GetRValue(c)+GetGValue(c)+GetBValue(c))/3);
    neuro_web[i].memory[x,y]:=l;

    end;
       end;

       p.Free;

   end;

   //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
procedure recognize();
   var  x,y,i,n,m,max,max_n:integer;
    c:TColor;
    p:TBitmap;
    s:string;
    r:Trect ;
 begin
Form1.ListBox2.Clear;
       max:=0;
       max_n:=0;
       r.Left:=0;
       r.Right:=30;
       r.Top:=0;
       r.Bottom:=30;
 for x:=0 to 29 do
  for y:=0 to 29 do    begin
    c:=Form1.Image1.Canvas.Pixels[x,y];
     i:=round((GetRValue(c)+GetGValue(c)+GetBValue(c))/3);

     if  i<100 then   i:=0   else i:=255;
   img[x,y]:=i ;



    end;
        for i:=0 to 32 do
     for x:=0 to 29 do
     for y:=0 to 29 do
     neuro_web[i].input[x,y]:=img[x,y];

    for i:=0 to 32 do begin
      p:=TBitmap.Create;
      p.Width:=30;
      p.Height:=30;

           for x:=0 to 29 do
             for y:=0 to 29 do begin
                 n:=neuro_web[i].memory[x,y];
                 m:=neuro_web[i].input[x,y];

                 if ((abs(m-n)<120)) then
                if m<250 then  neuro_web[i].weight:=neuro_web[i].weight+1;
                if m<>0 then   begin
                  if m<250 then   n:=round((n+(n+m)/2)/2);
                      neuro_web[i].memory[x,y]:=n;   end
                else if n<>0 then
                  if m<250 then    n:=round((n+(n+m)/2)/2);
               neuro_web[i].memory[x,y]:=n;

             end;
              Form1.ListBox2.Items.Add(chr(Ord('А')+i)+' = '+IntToStr(neuro_web[i].weight));
         if neuro_web[i].weight>max then  begin
         max:=neuro_web[i].weight;
         max_n:=i;
         end;


    end;

    s:=InputBox('Enter the letter', 'Программа считает, что найдена буква '+neuro_web[max_n].name, neuro_web[max_n].name);
     for i:=0 to 32 do     begin
     if neuro_web[i].name=s then begin
       p.Canvas.TextOut(10,10,'asa');
         p.Canvas.Brush.Color:=clWhite;
        p.Canvas.Pen.Color:=clWhite;
        p.Canvas.FillRect(r);

         p.Canvas.Brush.Color:=clBlack;
        p.Canvas.Pen.Color:=clBlack;
      p.SaveToFile('aa.bmp');
    for x:=0 to 29 do   begin
    for y:=0 to 29 do        begin
     p.Canvas.Pixels[x,y]:=RGB(neuro_web[i].memory[x,y],neuro_web[i].memory[x,y],neuro_web[i].memory[x,y]);

     end;
      end;
       p.SaveToFile(ExtractFilePath(Application.ExeName)+'\res\'+neuro_web[i].name+'.bmp');
      end;
      end;
      max:=0;
      start();
end;
   //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

procedure TForm1.FormCreate(Sender: TObject);
  var i:integer;
  begin

  GetAllFiles( ExtractFilePath(Application.ExeName)+'\img', listbox1 );
   for i:=0 to 32 do
  neuro_web[i]:=Neuron.Create;
    start();

end;

procedure TForm1.ListBox1Click(Sender: TObject);
begin

Image1.Picture.LoadFromFile( ExtractFilePath(Application.ExeName)+'\res\'+ListBox1.Items.Strings[Listbox1.ItemIndex]);
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
recognize();
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
If OpenPictureDialog1.Execute then
Image1.Picture.LoadFromFile(OpenPictureDialog1.FileName);
recognize();
end;

procedure TForm1.ListBox1DblClick(Sender: TObject);
begin
Button1.Click;
end;

end.
