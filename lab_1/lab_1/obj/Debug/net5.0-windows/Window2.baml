   M S B A M L   `   `   `  ����@  <lab_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab_1lab_1  5   	       lab_1.Window2   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:lab_1     5   	   -   5          �Name$  	Tictactoe��5   	    � Title$ Tic-Tac-Toe��5   	   $	��450��6   $	��800��6*    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�6I   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFD3CE39��6   � 5      $ 	#FFF3F2DE��6    � Offset$ 1Q�6-   5      .��5      � .+�5   
   �� $
��Left=�6   $	��690��6+   $��256,-116,0,0q�68   $	��Top=�6N   $	��706��6f   $ ��/Adobe_20220212_114051.png��6r   �� 5   
   -   5         ��Name$ btn2ex��5      $��Головне вікно��6!   $
��Left=�69   $��39��6T   $��600,380,0,0q�6`   $	��Top=�6u   $	��143��6�   ���	#FFEAE8B0$��18(�6�   ���	#FF23595A	 � Cursor$
	 Hand��6�   �� 5   
   $#��Хрестики-нулики��6   $
��Left=�6*   $��93��6E   $��	50,35,0,0q�6Q   $	��Top=�6d   $	��373��6|   $��Segoe UI Light)�6�   $��43(�6�   ���	#FF085560$��Normal$�6�   $��Normal"�6�   �� 5   
   -   5        $	 XO1��5      $�� ��6   $
��Left=�6)   $��45��6D   $��110,129,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $	 XO2��5      $�� ��6   $
��Left=�6)   $��45��6D   $��155,129,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $	 XO3��5      $�� ��6   $
��Left=�6)   $��45��6D   $��200,129,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $	 XO4��5      $�� ��6   $
��Left=�6)   $��45��6D   $��245,129,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $	 XO5��5      $�� ��6   $
��Left=�6)   $��45��6D   $��290,129,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $	 XO6��5      $�� ��6   $
��Left=�6)   $��45��6D   $��110,174,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -	   5        $	 XO7��5      $�� ��6   $
��Left=�6)   $��45��6D   $��155,174,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -
   5        $	 XO8��5      $�� ��6   $
��Left=�6)   $��45��6D   $��200,174,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $	 XO9��5      $�� ��6   $
��Left=�6)   $��45��6D   $��245,174,0,0q�6P   $	��Top=�6e   $��45��6}   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $
 XO10��5      $�� ��6   $
��Left=�6*   $��45��6E   $��290,174,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $
 XO11��5      $�� ��6   $
��Left=�6*   $��45��6E   $��110,219,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $
 XO12��5      $�� ��6   $
��Left=�6*   $��45��6E   $��155,219,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5   
   -   5        $
 XO13��5      $�� ��6   $
��Left=�6*   $��45��6E   $��200,219,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5    
   -   5        $
 XO14��5       $�� ��6   $
��Left=�6*   $��45��6E   $��245,219,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5!   
   -   5        $
 XO15��5!      $�� ��6   $
��Left=�6*   $��45��6E   $��290,219,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5"   
   -   5        $
 XO16��5"      $�� ��6   $
��Left=�6*   $��45��6E   $��110,264,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5#   
   -   5        $
 XO17��5#      $�� ��6   $
��Left=�6*   $��45��6E   $��155,264,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5$   
   -   5        $
 XO18��5$      $�� ��6   $
��Left=�6*   $��45��6E   $��200,264,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5%   
   -   5        $
 XO19��5%      $�� ��6   $
��Left=�6*   $��45��6E   $��245,264,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5&   
   -   5        $
 XO20��5&      $�� ��6   $
��Left=�6*   $��45��6E   $��290,264,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5'   
   -   5        $
 XO21��5'      $�� ��6   $
��Left=�6*   $��45��6E   $��110,309,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5(   
   -   5        $
 XO22��5(      $�� ��6   $
��Left=�6*   $��45��6E   $��155,309,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5)   
   -   5        $
 XO23��5)      $�� ��6   $
��Left=�6*   $��45��6E   $��200,309,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5*   
   -   5        $
 XO24��5*      $�� ��6   $
��Left=�6*   $��45��6E   $��245,309,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5+   
   -   5        $
 XO25��5+      $�� ��6   $
��Left=�6*   $��45��6E   $��290,309,0,0q�6Q   $	��Top=�6f   $��45��6~   ���	#FFFFFDD6���	#FF070804$��30(�6�   $��Bradley Hand ITC)�6�   6�   �� 5,   
   -   5        
 ��Name$
 	winnercon��5,      $�� ��6#   $
��Left=�6.   $��51��6I   $��
80,358,0,0q�6U   $	��Top=�6i   $	��300��6�   ���	#FFD9D559$��25(�6�   5.      5/      