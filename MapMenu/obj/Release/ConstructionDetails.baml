   M S B A M L   `   `   `  ���� F  BImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8+clr-namespace:Controls;assembly=ImageButtonControls  G CYearSelector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:YearSelector;assembly=YearSelectorYearSelector K GWpfZommPanCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvasWpfZommPanCanvas I EInterActiveMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:InterActiveMap;assembly=InterActiveMapInterActiveMap I ELocalizedImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LocalizedImage;assembly=LocalizedImageLocalizedImage O KLocalizedImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:LocalizedImageButton;assembly=LocalizedImageButtonLocalizedImageButton  ArcView Demo!   MapMenu.ConstructionDetails   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 8x,http://schemas.microsoft.com/winfx/2006/xaml   	 7c+clr-namespace:Controls;assembly=ImageButton   	 <p0clr-namespace:YearSelector;assembly=YearSelector   	 SWpfZommPanCanvas8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvas   	 MInterActiveMap4clr-namespace:InterActiveMap;assembly=InterActiveMap   	 @L4clr-namespace:LocalizedImage;assembly=LocalizedImage   	 NLoc@clr-namespace:LocalizedImageButton;assembly=LocalizedImageButton   	 -     � Title$  ConstructionDetails��$	��720��$
��1280�� � WindowState$ Normal=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Topmost .   � 	Resources    GlassButton �� 
TargetType � 	Resources  Key	 g� 	BeginTime
 �� 
TargetName �� TargetProperty O� KeyTime O� Value �� CornerRadius ��Name � RowDefinitions J� Opacity �� RelativeTransform �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y � Color � Offset �� EndPoint �� 
StartPoint �� Triggers P� Property  P� Value! �� 
TargetName" �� Property# �� Value$ N� EnterActions  	Timeline1% N� ExitActions& ��Name  	Timeline2��%�  &	        7  7  �� " �� ���� 	Timeline1 .��U� $	 00:00:00X�$

 glow��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 1Q��� 	Timeline2 .��U� $	 00:00:00X�$

 glow��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��� ���	#FFFFFFFF$��1,1,1,1q�$ 4,4,4,4��._��� $ border�����	#7F000000���	#FF000000$��1,1,1,1q�$ 4,4,4,4��._��  �� $��0.507* ��� $��0.493* �.+��� $
 glow��$ 0Q�$��Stretch=�$
��Auto��$��2��$ 4,4,4,4����
�  V� .~��� $ 1.702Q�$ 2.243Q��� $ 0Q�$ 0Q��� $ 0Q�T� $ -0.368Q�$ -0.152Q�.��� $ 	#B28DBDFF��$ 0Q�� $ 	#008DBDFF��$ 1Q��� $��Center=�$��Center=�$
��Auto��$��2���� $ shine��$��Stretch=�$��0,0,0,0q�$
��Auto��$ 4,4,0,0������ $ 0.494,0.889&�$ 0.494,0.028&�.��� $ 	#99FFFFFF��$ 0Q�� $ 	#33FFFFFF��$ 1Q� P�  � ��  . . ��� $! shine��" �@J�Opacity$	# 0.4Q��� $! border��" � ��# �	#CC000000�� $
! glow��" � y�$# Hidden=�P�  �@J�IsMouseOver  . $ �� 8��  % �� $& Timeline2_BeginStoryboard��8�� .���� $
��1280��$	��720��.+��� $��
0,83,0,104q�$,��&Properties\timeline-top-middelarea.png��$
��Fill=�$	��538��
' �� Top$' 16.867��( �� Left$( 0��$
��1280��  LocalizedImage.LocImage  $��0,0,0,0q�$	��Top=�)   AraImage$+) %Images\timeline-top-Constructions.png��$
��1280��$	��107��*   	IsEnglish* �� + �� Path$+ lng.isEnglish�, �� Current- �� Source#- Z, A0clr-namespace:YearSelector;assembly=YearSelectorYearSelector   YearSelector.YearSelector  =my0clr-namespace:YearSelector;assembly=YearSelector   	 -   $��	ySelector��$��2��$��82��$��Bottom=�$( 0��$	' 638��$��704.497��  WpfZommPanCanvas.ZPCanvas  -   $��zpCanvas��.   FullCanvasSize$. 	3422,5388��$��463.59��$( 15.453��$' 113.625��$��668.115��}�. |�. /   	IsFreezed/ . 0   Children.0   InterActiveMap.MapViewer  -   $��
MapViewer1��|�. 1 K� ZIndex$1 8��2   	IsFreezed2 . �� $��0,100,-244,124q�$*��$Properties\timeline-zonesmapMask.png��$
��Fill=�$( 0.167��$��701.066��|�.  3 J� IsHitTestVisible3 .  {�.      Controls.AnimatedWrapPanel  -   $��wPanel��$��81,91,239,0q�$��460.047��$	��Top=�$��1��$	( 668��$	��498��$' 45��   Controls.ImageButton  -   4   OriginalImage$4 /BTImages/HomeBtn.png��5   MouseOverImage$!5 /BTImages/HomeBtn-Hilit.png��$��29.997��$��30��$( 1199.88��$' 12��  -   $"4 /BTImages/Turn-offBtn-on.png��$%5 /BTImages/Turn-offBtn-Hilit.png��$��30��$
��Left=�$
( 1238��$��30��$' 12���� -   $��ZoneNameLBL��$	( 608��$' 56��$��42��$	��659��$��26(�$��khalaad al-arabeh)�
�������$��Center=�$��RightToLeft=�