object Form1: TForm1
  Left = 192
  Top = 114
  BorderStyle = bsToolWindow
  Caption = 'Form1'
  ClientHeight = 315
  ClientWidth = 933
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Image1: TImage
    Left = 8
    Top = 8
    Width = 300
    Height = 300
    Stretch = True
  end
  object ListBox1: TListBox
    Left = 312
    Top = 8
    Width = 193
    Height = 273
    ItemHeight = 13
    TabOrder = 0
    OnClick = ListBox1Click
    OnDblClick = ListBox1DblClick
  end
  object Button1: TButton
    Left = 312
    Top = 285
    Width = 193
    Height = 25
    Caption = #1054#1090#1082#1088#1099#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object ListBox2: TListBox
    Left = 512
    Top = 8
    Width = 97
    Height = 273
    ItemHeight = 13
    TabOrder = 2
  end
  object Button2: TButton
    Left = 512
    Top = 285
    Width = 97
    Height = 25
    Caption = #1042#1099#1091#1095#1080#1090#1100
    TabOrder = 3
  end
  object Panel1: TPanel
    Left = 616
    Top = 8
    Width = 305
    Height = 145
    TabOrder = 4
  end
  object Panel2: TPanel
    Left = 616
    Top = 168
    Width = 305
    Height = 145
    TabOrder = 5
  end
  object Button3: TButton
    Left = 616
    Top = 288
    Width = 75
    Height = 25
    Caption = 'rec'
    TabOrder = 6
    OnClick = Button3Click
  end
  object OpenPictureDialog1: TOpenPictureDialog
    Left = 168
    Top = 344
  end
  object XPManifest1: TXPManifest
    Left = 760
    Top = 208
  end
end
