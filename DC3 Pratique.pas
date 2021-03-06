Program DC3;
uses wincrt;

Type
	enreg = Record
					IndD,IndF,nbr:Integer;
					Seq:string;
					End;
tab = Array[1..20] of Integer;
tab1 = Array[1..100] of enreg;

Var
	F:Text;
	T:tab;
	V:tab1;
	N,k:Integer;

Procedure RempT(var T:tab; var N:Integer);
var i :integer;
Begin
	Repeat
		Writeln('Donner la taille du tableau: ');
		Readln(N);
	Until (N in [2..20]);
	For i := 1 to N Do
		Begin
			Writeln('Donner T[',i,']: ');
			Readln(T[i]);
		end;
end;

Procedure RempV(var V:tab1; T:tab; var k:Integer; N:integer);
var i,j,c:integer;
	ch,ch1:String;
Begin
		i := 0;
		k := 0;
		Repeat
			i := i + 1;
			j := i;
			ch := '';
				while ((T[j] mod 2 =0) and (j<=n)) Do
					j := j +1;
				if (j - i >= 2) Then
					Begin
						k := k +1;
						V[k].IndD := i;
						V[k].IndF := j-1;
						V[k].Nbr := j - i;
						For c := i to j-1 Do
							Begin
								Str(T[c],ch1);
								ch := ch + ch1 + '|';
							end;
						Delete(ch,Length(ch),1);
						V[k].Seq := ch;
						i := j-1;
					end;
	 Until (i >=n);
end;

Function Remplacer(ch:string):string;
var i :integer;
Begin
	For i := 1 to Length(ch) Do
		if (ch[i] = '|') Then
			ch[i] := ',';
	Remplacer:= ch;		
end;
			
Procedure RempF(var F:Text; V:tab1; k:integer);
Var
	i,max,ind:Integer;
Begin
	ReWrite(F);
	max := V[1].Nbr;
	ind := 0;
	 For i := 1 to k Do
	 		if (V[i].Nbr > max) Then
				Begin
					max := V[i].Nbr;
					ind := i;
				end;
		Writeln(F,'La sequence la plus longue est: ',max);
		Writeln(F,'Les elements de cette sequence: ',Remplacer(V[ind].Seq));
	Close(F);	
end;		

Procedure Affiche(var F:Text);
var ch:string;
Begin
Reset(F);
While (not(eof(F))) Do
	Begin
		Readln(F,Ch);
		Writeln(ch);
	end;
	Close(F);
end;
Begin
	Assign(F,'C:\PASCALXE\Séquence.txt');
	RempT(T,N);
	RempV(V,T,K,N);
	RempF(F,V,k);
	Affiche(F);
end.