   M S B A M L   `   `   `  ���� G  CArcView Demo, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MapMenu.EntryFormsMapMenu.EntryForms  #    MapMenu.EntryForms.DataUpload   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5
EntryForms clr-namespace:MapMenu.EntryForms    -   $��DataUploadW��  � Title$  
DataUpload��$	��719��$	��862�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=� � Topmost .  � 	Resources +   %MapMenu.EntryForms.ImagePathConverter   LocalUriToImageConverter��%   &	          .���� $	��684��$��0,0,0,0q�.+��� -   $��label1��$��28��$
��Left=�$��	12,12,0,0q�$	��Top=�$	��120��.��Metadata Catigory�� -   $��label2��$��28��$
��Left=�$��	12,12,0,0q�$	��Top=�$	��231�� �� Left$ 0��
 �� Top$ 63��.��Drag / Drop Files Here�� -   $��	comboBox1��$	 138��$ 17��$��23��$	��282�� �� SelectedIndex$ 0���� -   $��listBox1��$ 12��$	 104��$	��520��$	��816��	 J� 	AllowDrop	 . 
���   �$��Disabled=����� 
 �� Path$
 Files� �� ElementName$ DataUploadW�� �� Mode$ TwoWay=����� .R��� ���	#88000000
�������$��2q� �� CornerRadius$ 6��$��5,5,5,5q�._��� $	��256��$	��230��.+��� $
��Auto��$��20��$��0,0,0,0q�.+��� -   $��20��$��20��$ 0������ .R��� $��Right=� J� OpacityMask �	#FF000000$��/Images/Remove.png�� � ToolTip$) #Click to remove the image from list���� $��20��$��20��$ 25������ .R��� $��Right=� �	#FF000000$��/Images/Warning.png��y��� *HasValidTitle+$ This image has no title.���� $��20��$��20��$ 50������ .R��� $��Right=�$��/Images/database.png��y��� *IsInDataBase+$$ This file exit in the databae.���� ���	#00FFFFFF
�������$��30��$��14(����� $
 CatName��� ���	#00FFFFFF
�������$��30��$��20(����� $
 Title��� $	��Top=�$	��256��$	��160��$��Uniform=����� $
 FileName� �� 	Converter# [  ���� .R�� $	��850��$��Disabled=�$��Visible=�$
��Left=��� -   $��Month��$	 138��$ 46��$��23��$��75�� �� Text$ Month��$ 0��.@��� .��01�� .��02�� .��03�� .��04�� .��05�� .��06�� .��07�� .��08�� .��09�� .��10�� .��11�� .��12�� -   $
��Year��$	 219��$ 46��$��23��$��75��$
 Year��$ 0��.@��� .��2009�� .��2010�� .��2011�� .��2012�� -	   $��CancelBT��$	 753��$	 630��$��24��$��75��.��Cancel�� -
   $��SaveBT��$	 672��$	 630��$��24��$��76��.��Save�� -   $��label4��$ 12��$ 41��$��28��$	��120��.��
Entry Date�� -   $��	ClearList��$ 13��$	 630��$��24��$��75��$ Clear All items��.��
Clear List�� -   $��
SavingInfo��$	 121��$	 630��$��28��$	��537��$
��Bold"�$��12(�
���   � � ForceCursor .  