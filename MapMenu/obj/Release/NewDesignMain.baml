   M S B A M L   `   `   `  ���� D  @ZonesList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ZonesList;assembly=ZonesList	ZonesList  K GWpfZommPanCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvasWpfZommPanCanvas I EInterActiveMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:InterActiveMap;assembly=InterActiveMapInterActiveMap F BImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8+clr-namespace:Controls;assembly=ImageButtonControls I ELocalizedImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LocalizedImage;assembly=LocalizedImageLocalizedImage  ArcView Demo   MapMenu.NewDesignMain   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    6z*clr-namespace:ZonesList;assembly=ZonesList    SWpfZommPanCanvas8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvas    MInterActiveMap4clr-namespace:InterActiveMap;assembly=InterActiveMap    >Controls+clr-namespace:Controls;assembly=ImageButton    @L4clr-namespace:LocalizedImage;assembly=LocalizedImage    -     �Name$  Window�� � Title$ Design Main��$
��1280��$	��720�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Topmost .  
���   � � ShowInTaskbar .   � 	Resources    GlobeIntro2_wmv g� 	BeginTime	 p� Source
 �� 
TargetName �� TargetProperty O� KeyTime O� Value��%Z  &	        �� .��p� $ 00:00:00X�$	 GlobeIntro3.wmv?�$
 GlobeIntro2_wmv��U� $ 00:00:00X�$
 GlobeIntro2_wmv��$ (UIElement.Opacity)�.\��� $ 
00:00:13.5��$ 1Q��� $ 00:00:14.5000000��$ 0Q�U� $ 00:00:00X�$
 InterfaceUI��$ (UIElement.Opacity)�.\��� $ 
00:00:13.5��$ 0Q��� $ 
00:00:15.0��$ 1Q�.���� -    ��Name$ 
LayoutRoot��$
��1280��$	��720��$��0,0,0,0q�.+��� -   $��Introv��$
��1280��$	��720��$y�	Collapsed=�.+�r� -    r�Name$ GlobeIntro2_wmv��$��0,0,0,0q� r� Stretch$
 none=�$
��1280��$	��720���� -   $��InterfaceUI��$
��1280��$	��720��$y�Visible=� J� Opacity$ 1Q�.+��� $,��&Properties\timeline-top-middelarea.png��$
��Fill=�$	��620�� �� Left$ 0��
 �� Top$	 100��$
��1280��(� $	��300��$	��440��$ 119.0��$ 43��.���� -   $	��VVV��$
��3422��$
��5388��$ 0��$ 0��.+��� $
��3422��$
��5388��$ 0��$ 0����!�  j� Stretch$ Uniform=� !� Visual ��  �� ElementName$ 
MapViewer1���� -   $��	ZoomedMap��$	��668��$	��465��$ 0��$ 0��
���  ��$ .4Q��� $
��Left=�$��14.238,109,0,130q�$��320.00��$)��#Properties\timeline-fullmapMask.png��$
��Fill=�$��464.429��$
 2.46��$ 15.771��  WpfZommPanCanvas.ZPCanvas  -   $��InterActiveMap��   FullCanvasSize$ 	3422,5388��$��465.0��$	 505��$	 107��$��668.0��}�.  J� SnapsToDevicePixels .     Children.   InterActiveMap.MapViewer  -	   $��
MapViewer1��   BackGroundImage$ zones-2008-12-29.jpg��|�.  K� ZIndex$ 8�� .  �� $��492,94,87,130q�$*��$Properties\timeline-zonesmapMask.png��$
��None=�|�.  {�.   J� IsHitTestVisible .    LocalizedImage.LocImage  $��0,0,0,0q�$	��Top=�   AraImage$$ Images\timeline-top-Design.png��$
��1280��$	��107��   	IsEnglish ��  �� Path$ lng.isEnglish�  �� Current! �� Source#! Z     ZonesList.ZonesList  -
   $��589,49,36,0q�$	��Top=�$��48��$ 4��$ 12��$	��655��  Controls.ImageButton  -   "   OriginalImage$" /BTImages/HomeBtn.png��#   MouseOverImage$!# /BTImages/HomeBtn-Hilit.png��$��29.997��$��30��$ 1199.88��$ 12��  -   $"" /BTImages/Turn-offBtn-on.png��$%# /BTImages/Turn-offBtn-Hilit.png��$��30��$
��Left=�$
 1238��$��30��$ 12��  -   $" /BTImages/ZoominBtn.png��$## /BTImages/ZoominBtn-Hilit.png��$��30��$��30��$	 515��$ 596.25��  -   $" /BTImages/ZoomoutBtn.png��$$# /BTImages/ZoomoutBtn-Hilit.png��$��30��$��30��$ 541.25��$ 596.25��  -   $��EditIcon��$!" /BTImages/DataEntryBtn1.png��$'# !/BTImages/DataEntryBtn1-Hilit.png��$��30��$��30��$	 573��$ 596.25��$y�	Collapsed=�  -   $��ShowDetails��$!" /BTImages/MapDetailsBtn.png��$'# !/BTImages/MapDetailsBtn-Hilit.png��$ 1154.659��$	 596��$��47��$��38.341��