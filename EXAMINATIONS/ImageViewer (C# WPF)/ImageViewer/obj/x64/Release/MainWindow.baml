   M S B A M L   `   `   `  ���� F  BImageViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ImageViewerImageViewer      ImageViewer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ImageViewer     -   $	��700��$	��900��  � WindowStyle$
  None=� � AllowsTransparency .  � Title$ Image Viewer�� � Icon$# Resources/picture-gallery.png��   VS2012WindowStyle#��[   � WindowStartupLocation$ CenterScreen=� � 	Resources   ScrollBarLineUpButtonStyle �� 
TargetType �� Property �� Value	 � Points
 �� Triggers P� Property P� Value " ScrollBarLineBottomButtonStyle ! ScrollBarLineRightButtonStyle   ScrollBarLineLeftButtonStyle  ScrollBarPageButtonStyle �� 
TargetType  ScrollBarThumbStyle  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions 	 BorderStyle 
 	ImgButton  
NodeButton  	MenuStyle��%�	  &	       &	 �     &	 �    &	 �    &	 �    &	 K    &	     7  7  7  7  7  &	 j    7  7  7  7  7  &		 �    &	
 H    &	 �    &	 �    �� " ��.���  � �� .  ��  � |� .  ��  � �� �� .R��� $��14��.+�� '	 �    	=  � ���  � @T�  	= ���� " �.���  � �� �#686868
 P�  �@J�IsMouseOver . . ���  � �� �#868686�� " ��.���  � �� .  ��  � |� .  ��  � �� �� .R��� $��14��.+�� '	 �    	= �� ��� �� @T� ��� ���� " �.���  � �� �#686868
 P�  �@J�IsMouseOver . . ���  � �� �#868686�� " ��.���  � �� .  ��  � |� .  ��  � �� �� .R��� $��14��.+�� 	 �    	=  z @T� ��� ���� " �.���  � �� �#686868
 P�  �@J�IsMouseOver . . ���  � �� �#868686�� " ��.���  � �� .  ��  � |� .  ��  � �� �� .R��� $��14��.+�� '	 �   ���  	= �� @T� ��� ��� ���� " �.���  � �� �#686868
 P�  �@J�IsMouseOver . . ���  � �� �#868686�� " ��.���  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� " n�.���  � �� .  ��  � |� .  ��  � �� �� " n�.R��� ���� " ��.���  � �� �#686868
 P�  �@J�IsMouseOver . . ���  � �� �#868686�� " ��.R�� ���#3e3e42$��0 0 -1 0q� �� $��14 ��� $��* ��� $��14 �.+��� $��0��$��ScrollBar.LineUpCommand��8��  ]� $��
PART_Track��$��1����. $��4q� �� $��ScrollBar.PageUpCommand��8��  n� 8��  �� $��ScrollBar.PageDownCommand��8�� �� $��2��$��ScrollBar.LineDownCommand��8�� �� " ��.R�� ���#3e3e42$��
-1 0 -1 -1q� �� $��10 ��� $��* ��� $��10 �.+��� $��0��$��ScrollBar.LineLeftCommand��8��  ]� $��
PART_Track��$��1����.  $��4q� �� $��ScrollBar.PageLeftCommand��8��  n� 8��  �� $ ��ScrollBar.PageRightCommand��8�� �� $��2��$ ��ScrollBar.LineRightCommand��8�� �� .���  � �� �#3f3f46��  � ��$ 1q���  � ��$ 5q���  � �� �#252526��  � ��$ 5q��� " ��.R��� $��-5q�
������ .+��� $��5q�.+��� �� " ��.R��� $��Stretch=�$��-2 0 0 0q�
������ .+��� �� .���  � �� �#2D2D30��  � �� �#FFF.��� ���#2D2D30$	��345�� �� $��24 ��� �� $	��180 ��� $��24 � �� .+��� $��0��.+�o�  c� OverflowMode$ Never=�#��[ .@�m� $��Файл�� � Cursor$
 Hand��#��[ .@�m� -   $��Открыть�����#000m� -   $��Закрыть�����#000m� -   $��MenuImg��$��Изображение��$
 Hand��#��[ {�.  .@�m� $��Вращать�����#000.@�m� -   $��На 90° вправо�����#000
 � Tag$ 90��m� -   $��На 90° влево�����#000$	 270��m� -   $��
На 180°�����#000$	 180��m� -   $��Сделать серым�����#000m� -	   $��MenuSlideShow��$��Слайд-шоу��{�.  � $��1�� �� $��30��$��* ��� $
��Auto ��� $��30��$��4* �.+�R� -
   $��folders��#��[	 $��Disabled=�$��0��$��0�� ��%-   '��       7  �� " ��.���  � ��8   ����  �� ItemsSource �� *Nodes+.R��� -   #��[ $
 Hand������ *ActualWidth+ �� XPath$ Parent�� �� *Self+.���� $��Stretch=����#FFF���� *
fileName+�� $��	-5 5 -5 5q�$ SizeWE��$��0��$��1��$��Stretch=� �� ShowsPreview .  $��5��$��Center=�
������ �� -   $��
WrapViewer��}�. #��[	 $��0��$��2��._��� -   $��ImageViewer���� -   $��	ImageList��$��Disabled=�#��[	  %� 
ScrollUnit$ Pixel=�$��2������ *Images+ ��%-   '��       7  �� " ��.���  � ��8   ���� .R�$� $��Center=� $� Orientation$ 
Horizontal=�$��Disabled=����� .R��� -   $
 Hand��$	��200��$	��130��$��Stretch=�$��Stretch=�#��[
  �� *Info+.��� $	��200��$	��130��$��Stretch=�$��Stretch=� �� �� $��24 �.+��� ���� *Source+���� *
Stretching+�� $��14(�$��24��$��Bottom=�
�������$��1��$��Center=����� *Name+�� $��3��.@��� -   $��
StatusText��$��3 0 0 0q�Готово�� $��Right=�.����  J� Opacity$
 0.75Q�