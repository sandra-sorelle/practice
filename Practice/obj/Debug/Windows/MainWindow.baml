   M S B A M L   `   `   `  ����C  ?Practice, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PracticePractice  5   	       Practice.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Practice     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � .+�5   
   �� -   5         ��Name$ ClientListView��5      $��20(�6-   $��Comic Sans MS)�6=   $��1��6Z   $
��Left=�6i   ��5      �� 5      .R�5      �� 
�������$��5q�62    �� Padding$ 10q�6?   $��Center=�6N   $	��350��6k    �� CornerRadius$ 2��6w    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 4Q�6/      Color$ 	LightGray��6@      ShadowDepth$ 0Q�6T   ._�5      �� $
��Left=�6%   .+�5      �� ��5   "   `� 5   &    �� StringFormat$ {0} {1} {2}��63   .1�5   *   �� 	 �� Path$	 ClientSurname�62   �� 5   *   $	 
ClientName�62   �� 5   *   $	 ClientPatronymic�62   5   '   5      �� 5      ��5   "   `� 5   &   $ Телефон: {0}��63   .1�5   *   �� $	 ClientPhone�62   5    '   5"      �� 5#      
 �� Orientation$
 
Horizontal=�6)   .+�5$   "   ��  ��Name$ 
EditButton��6Y   -   5        ���#AA87B1$��25��5$   >   $��25��6K   6o   �� 5%   "   $ DeleteButton��6Y   -   5        ���#AA87B1$��25��5%   >   $��25��6K   6q   5&      5'      5(      5)      5+      5,      5-      