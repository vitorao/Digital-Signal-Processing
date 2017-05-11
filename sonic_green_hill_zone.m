clear;
fs = 8000;
Ts = 1/fs;
metronomo = 150;

minima = (2*60)/metronomo;
seminima = (1*60)/metronomo;
colcheia = (0.5*60)/metronomo;
semicolcheia = ((1/4) * 60) / metronomo;
minimaponto = ((2+(2/2)) * 60) / metronomo;
pausa_sm = sin(2*pi*0*(0:Ts:seminima));

%notas 5 de semicolcheia
G5_sc = sin(2*pi*784*(0:Ts:semicolcheia));
F5_sc = sin(2*pi*698.5*(0:Ts:semicolcheia));
A5_sc = sin(2*pi*880*(0:Ts:semicolcheia));
B5_sc = sin(2*pi*987.8*(0:Ts:semicolcheia));

%notas 6 de semicolcheia
G6_sc = sin(2*pi*1568*(0:Ts:semicolcheia));
D6_sc = sin(2*pi*1175*(0:Ts:semicolcheia));
C6_sc = sin(2*pi*1047*(0:Ts:semicolcheia));
E6_sc = sin(2*pi*1319*(0:Ts:semicolcheia));

%notas 5 de minima
F5_m = sin(2*pi*698.5*(0:Ts:minima));

%notas 5 de seminima
G5_sm = sin(2*pi*784*(0:Ts:seminima));
A5_sm = sin(2*pi*880*(0:Ts:seminima));
B5_sm = sin(2*pi*987.8*(0:Ts:seminima));
F5_sm = sin(2*pi*698.5*(0:Ts:seminima));

%notas 6 de seminima
D6_sm = sin(2*pi*1175*(0:Ts:seminima));

%notas 5 de colcheia
A5_c = sin(2*pi*987.8*(0:Ts:colcheia));
F5_c = sin(2*pi*698.5*(0:Ts:colcheia));
G5_c = sin(2*pi*784*(0:Ts:colcheia));
C5_c = sin(2*pi*523.3*(0:Ts:colcheia));

%notas 6 de colcheia
C6_c = sin(2*pi*1047*(0:Ts:colcheia));
E6_c = sin(2*pi*1319*(0:Ts:colcheia));

%notas pontuadas
G5_p = sin(2*pi*784*(0:Ts:minimaponto));

compasso1 = [ A5_sc, F5_sc, A5_sc, F5_sc, B5_sc, G5_sc, B5_sc, G5_sc, C6_sc, A5_sc, C6_sc, A5_sc, D6_sc, B5_sc, D6_sc, B5_sc];
nota2     = [ E6_sc, C6_sc, E6_sc, C6_sc];
parte1    = [ compasso1, nota2, nota2, nota2, nota2, nota2, nota2, E6_sc];

compasso2 = [ C6_c, A5_sm, C6_c, B5_sm, C6_c, B5_sm, G5_p ];
compasso3 = [ G5_c, E6_c, D6_sm, C6_c, B5_sm, C6_c, B5_sm, G5_c];
compasso4 = [ A5_c, A5_c, F5_sm, A5_c, G5_sm, A5_c, G5_sm, C5_c ];

%song = [compasso1, compasso2, compasso3, compasso2,  compasso4, compasso2, compasso3, compasso2, compasso4 ]; %parte1;
song = [compasso2, compasso3,compasso2, compasso4];
sound(song);

t = linspace(1, length(song)/fs, length(song));

%plota o gráfico no dominio do tempo
subplot(211);
plot (t, song);
xlabel('Tempo(s)');
ylabel('Amplitude');
title('Dominio do Tempo');
