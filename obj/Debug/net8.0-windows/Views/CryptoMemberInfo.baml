   M S B A M L   `   `   `  ����G  CCryptoViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CryptoViewer.ViewsCryptoViewer.Views  5      )    #CryptoViewer.Views.CryptoMemberInfo   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CryptoViewer.Views     5      -   5          >�Name$
  this��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value�� 5   
   %�   '��       �� 5      " ��6   .�5      ��  � ��$ Center=�66   �� 5       � ��$ 20(�6-   �� 5       �@��Padding$ 5 5 0 0q�6,   �� 5       �@��
LineHeight$ 30��6/   5      5      .��5      �� $
��Auto=�6   $��Disabled=�68   .��5   
   �� 
�������$��1q�6&   ._�5      �� .+�5      �� ��6   ��  �� ElementName$
 this�� �� Path$ Member.CryptoInfo�6f   �� 5      ��5      �� 5      " ��6     �� BasedOn# [B��67    �� Triggers 5      �� 5   "   	 �� Binding	 6.   �� $
 this��$ Member.Explorer�
 �� Value
 6i   Z� .a�5   &   ��  � y�$ 	Collapsed=�6C   5   #   5!      �� 5#      $�Link - ��6    �� 5$      -   5        ��5$      �� $
 this��$ Member.Explorer�.�5%   E   .�5&      �� �6   �� $
 this��$ Member.Explorer�5'      5(      5)      5*      5+      5,      