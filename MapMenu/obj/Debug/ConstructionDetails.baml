   M S B A M L   `   `   `  ����F  BImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8+clr-namespace:Controls;assembly=ImageButtonControls  5      G CYearSelector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:YearSelector;assembly=YearSelectorYearSelector 5      K GWpfZommPanCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvasWpfZommPanCanvas 5      I EInterActiveMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:InterActiveMap;assembly=InterActiveMapInterActiveMap 5      I ELocalizedImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LocalizedImage;assembly=LocalizedImageLocalizedImage 5      O KLocalizedImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:LocalizedImageButton;assembly=LocalizedImageButtonLocalizedImageButton 5	   	    JOM Interactive Report!   MapMenu.ConstructionDetails   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 5      8x,http://schemas.microsoft.com/winfx/2006/xaml   	 5      7c+clr-namespace:Controls;assembly=ImageButton   	 5      <p0clr-namespace:YearSelector;assembly=YearSelector   	 5      SWpfZommPanCanvas8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvas   	 5      MInterActiveMap4clr-namespace:InterActiveMap;assembly=InterActiveMap   	 5      @L4clr-namespace:LocalizedImage;assembly=LocalizedImage   	 5      NLoc@clr-namespace:LocalizedImageButton;assembly=LocalizedImageButton   	 5	   	   -   5          � Title$  ConstructionDetails��5
      $	��720��6!   $
��1280��6.    � WindowState$ Normal=�6;    � WindowStyle$
 None=�6P    � 
ResizeMode$ NoResize=�6c    � WindowStartupLocation$ CenterScreen=�6y    � Topmost .   � 	Resources 5         GlassButton �� 
TargetType � 	Resources  Key	 g� 	BeginTime
 �� 
TargetName �� TargetProperty O� KeyTime O� Value �� CornerRadius ��Name � RowDefinitions J� Opacity �� RelativeTransform �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y � Color � Offset �� EndPoint �� 
StartPoint �� Triggers P� Property  P� Value! �� 
TargetName" �� Property# �� Value$ N� EnterActions  	Timeline1% N� ExitActions& ��Name  	Timeline2��%�  &	        7  7  �� 5   
   " ��6.    5      ���� 5      	Timeline1 .��5      U� $	 00:00:00X�64   $

 glow��6I   $ (UIElement.Opacity)�6f   .\�5      �� $ 00:00:00.3000000��6/   $ 1Q�6J   5      5      �� 5      	Timeline2 .��5      U� $	 00:00:00X�64   $

 glow��6I   $ (UIElement.Opacity)�6f   .\�5      �� $ 00:00:00.3000000��6/   $ 0Q�6J   5      5      5      .R�5      �� ���	#FFFFFFFF$��1,1,1,1q�6-   $ 4,4,4,4��6G   ._�5      �� $ border��6   ���	#7F000000���	#FF000000$��1,1,1,1q�6X   $ 4,4,4,4��6r   ._�5      �  5      �� 5      $��0.507* �6,   �� 5      $��0.493* �6,   .+�5       �� $
 glow��6K   $ 0Q�6!   $��Stretch=�6-   $
��Auto��6Y   $��2��6f   $ 4,4,4,4��6w   ��5!      
� 5"   "    5#   &   V� 5$   *   .~�5%   .   �� $ 1.702Q�6=   $ 2.243Q�6L   �� 5&   .   $ 0Q�6<   $ 0Q�6G   �� 5'   .   $ 0Q�6>   T� 5(   .   $ -0.368Q�6A   $ -0.152Q�6L   5)   +   .��5+   &   � $ 	#B28DBDFF��63   $ 0Q�6E   � 5,   &   $ 	#008DBDFF��63   $ 1Q�6E   5-   #   5/      �� 50      $��Center=�6+   $��Center=�6H   $
��Auto��6c   $��2��6p   �� 51      $ shine��6P   $��Stretch=�6!   $��0,0,0,0q�6?   $
��Auto��6_   $ 4,4,0,0��6l   ��52      �� 53   "   $ 0.494,0.889&�66   $ 0.494,0.028&�6M   .��54   &   � $ 	#99FFFFFF��63   $ 0Q�6E   � 55   &   $ 	#33FFFFFF��63   $ 1Q�6E   56   #   58      59      5:      5;       5<      P� 5=       � ��  . . �5>      �� $! shine��60   " �@J�Opacity$	# 0.4Q�6C   �� 5?      $! border��63   " � ��# �	#CC0000006G   �� 5@      $
! glow��63   " � y�$# Hidden=�6E   5A      P� 5B       �@J�IsMouseOver  . $ 5C      �� 5D      8��  6*   % 5F      �� 5G      $& Timeline2_BeginStoryboard��6*   8�� 6M   5I      5K      5L      .��5M      �� $
��1280��6   $	��720��6   .+�5N   
   �� $��
0,83,0,104q�6   $,��&Properties\timeline-top-middelarea.png��6$   $
��Fill=�6T   $	��538��6c   
' �� Top$' 16.867��6p   ( �� Left$( 0��6�   $
��1280��6�     LocalizedImage.LocImage  5P      $��0,0,0,0q�6   $	��Top=�6"   )   AraImage$+) %Images\timeline-top-Constructions.png��6;   $
��1280��6�   $	��107��6�   *   	IsEnglish* 6l   �� + �� Path$+ lng.isEnglish�, �� Current- �� Source#- Z, 6�   A0clr-namespace:YearSelector;assembly=YearSelectorYearSelector 5Q   f     YearSelector.YearSelector  6
   =my0clr-namespace:YearSelector;assembly=YearSelector   	 6f   -   5        $��	ySelector��5Q   :   $��2��6   $��82��6.   $��Bottom=�6K   $( 0��6�   $	' 638��6�   $��704.497��6�   6�     WpfZommPanCanvas.ZPCanvas  5R   
   -   5        $��zpCanvas��5R   ?   .   FullCanvasSize$. 	3422,5388��6$   $��463.59��6O   $( 15.453��6_   $' 113.625��6t   $��668.115��6�   }�. |�. /   	IsFreezed/ . 0   Children.0 5S        InterActiveMap.MapViewer  -   5        $��
MapViewer1��5S   '   |�. 1 K� ZIndex$1 8��6J   2   	IsFreezed2 . 6n   5T      �� 5U   
   $��0,100,-244,124q�6   $*��$Properties\timeline-zonesmapMask.png��6(   $
��Fill=�6V   $( 0.167��6e   $��701.066��6y   |�.  3 J� IsHitTestVisible3 .  {�.  6�       Controls.AnimatedWrapPanel  5V   
   -   5        $��wPanel��5V   �   $��81,91,239,0q�6   $��460.047��63   $	��Top=�6D   $��1��6\   $	( 668��6l   $	��498��6~   $' 45��6�   5W         Controls.ImageButton  5X   
   -   5        4   OriginalImage$4 /BTImages/HomeBtn.png��5X      5   MouseOverImage$!5 /BTImages/HomeBtn-Hilit.png��6>   $��29.997��6k   $��30��6z   $( 1199.88��6�   $' 12��6�   6�     5Z   
   -   5        $"4 /BTImages/Turn-offBtn-on.png��5Z      $%5 /BTImages/Turn-offBtn-Hilit.png��6E   $��30��6v   $
��Left=�6�   $
( 1238��6�   $��30��6�   $' 12��6�   6�   �� 5[   
   -   5        $��ZoneNameLBL��5[   >   $	( 608��6   $' 56��6"   $��42��62   $	��659��6Q   $��26(�6]   $��khalaad al-arabeh)�6k   
�������$��Center=�6�   $��RightToLeft=�6�   6�   5^      5_      