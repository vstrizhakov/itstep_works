program Neuro_symb;

uses
  Forms,
  neuro in 'neuro.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
