package com.vitorliberalino.folhasoftjava;


import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import android.view.View;

public class HoleriteActivity extends AppCompatActivity {


    String nomeUsuario;
    String descricao_cargo;
    Integer id_funcionario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_holerite);

        Intent intent = getIntent();

        nomeUsuario = intent.getStringExtra("NOME_EXTRA");
        descricao_cargo = intent.getStringExtra("DESCRICAOCARGO_EXTRA");
        id_funcionario = intent.getIntExtra("IDFUNCIONARIO_EXTRA", -1);











    }

    public void visualizarHolerite(View view){
        Intent intent = new Intent(HoleriteActivity.this, VisualizacaoHoleriteActivity.class);

        Spinner spinnerMes = findViewById(R.id.spinner_Mes);
        String mesSelecionado = spinnerMes.getSelectedItem().toString();
        Spinner spinnerAno = findViewById(R.id.spinner_Ano);
        String anoSelecionado = spinnerAno.getSelectedItem().toString();
        System.out.println("Mes selecionado: " + mesSelecionado);
        System.out.println("Ano selecionado: " + anoSelecionado);
        String mes_e_ano = "Mês: " + mesSelecionado + " | Ano: " + anoSelecionado;
        System.out.println("mes e ano: " + mes_e_ano);
        if((mesSelecionado.equals("Selecione") || anoSelecionado.equals("Selecione"))){

            Toast toast = Toast.makeText(HoleriteActivity.this, "Selecione o mês e o ano para visualizar o holerite!!!", Toast.LENGTH_SHORT);
            toast.setGravity(Gravity.CENTER, 0, 700);
            toast.show();



        }
            else {
            intent.putExtra("NOME_EXTRA", nomeUsuario);
            intent.putExtra("DESCRICAOCARGO_EXTRA", descricao_cargo);
            intent.putExtra("IDFUNCIONARIO_EXTRA", id_funcionario);
            intent.putExtra("MES_EXTRA", mesSelecionado);
            intent.putExtra("ANO_EXTRA", anoSelecionado);
            intent.putExtra("MESEANO_EXTRA", mes_e_ano);
            startActivity(intent);
        }

    }

    public void voltarMenuPrincipalH(View view) {
        finish();
    }


}