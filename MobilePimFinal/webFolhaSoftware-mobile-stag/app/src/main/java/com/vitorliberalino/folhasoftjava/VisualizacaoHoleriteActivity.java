package com.vitorliberalino.folhasoftjava;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import java.text.DecimalFormat;


import com.vitorliberalino.folhasoftjava.dao.UsuarioDAO;
import com.vitorliberalino.folhasoftjava.model.Descontos;
import com.vitorliberalino.folhasoftjava.model.FolhaPagamento;
import com.vitorliberalino.folhasoftjava.model.Usuario;

public class VisualizacaoHoleriteActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_visualizacao_holerite);



        Intent intent = getIntent();
        String nomeUsuario = intent.getStringExtra("NOME_EXTRA");
        String descricao_cargo = intent.getStringExtra("DESCRICAOCARGO_EXTRA");
        Integer id_funcionario = intent.getIntExtra("IDFUNCIONARIO_EXTRA", -1);
        int mesSelecionado = Integer.parseInt(intent.getStringExtra("MES_EXTRA"));
        int anoSelecionado = Integer.parseInt(intent.getStringExtra("ANO_EXTRA"));
        String mes_e_ano = intent.getStringExtra("MESEANO_EXTRA");
        System.out.println("ID rececebido: " + id_funcionario );

        FolhaPagamento folha = new UsuarioDAO().buscarFolha(id_funcionario, mesSelecionado, anoSelecionado);
        if (folha == null) {
            // Não há dados disponíveis para o mês e ano selecionados
            Toast toast = Toast.makeText(VisualizacaoHoleriteActivity.this, "Não há dados de pagamento para a data selecionada!!!", Toast.LENGTH_SHORT);
            toast.setGravity(Gravity.CENTER, 0, 700);
            toast.show();
            finish();
            return;
        }
        Descontos descontos = new UsuarioDAO().buscarDescontos();
        double salario = folha.getValor_pagamento();
        String evento = folha.getDescricao_evento();
        double inss = 0;
        double irrf = 0;
        double deducaoIrrf = 0;
        if (salario <= 1320){
            inss = 0.075;
        }
        else if (salario >= 1320.01 && salario <= 2571.29){
            inss = 0.09;
        }
        else if (salario >= 2571.30 && salario <= 3856.94 ){
            inss = 0.12;
        }
        else if(salario >= 3856.95){
            inss = 0.14;
        }

        if (salario <= 1903.99){
            irrf = 0;
            deducaoIrrf = 0;
        }
        else if (salario >= 1904 && salario <= 2826.65){
            irrf = 0.075;
            deducaoIrrf = 142.8;
        }
        else if (salario >= 2826.66 && salario <= 3751.05 ){
            irrf = 0.15;
            deducaoIrrf = 354.8;
        }
        else if(salario >= 3751.06 && salario <= 4664.68){
            irrf = 0.225;
            deducaoIrrf = 636.13;
        }
        else if(salario >= 4664.69){
            irrf = 0.275;
            deducaoIrrf = 869.36;
        }
        double descontoIrrf = salario * irrf - deducaoIrrf;
        double descontoInss = salario * inss;
        double salarioLiquido = salario - descontoInss - descontoIrrf;

        DecimalFormat formato = new DecimalFormat("#.00");
        String salarioFormatado = formato.format(salario);
        String inssFormatado = formato.format(descontoInss);
        String descontoIrrfFormatado = formato.format(descontoIrrf);
        String salarioLiquidoFormatado = formato.format(salarioLiquido);



        TextView nomeTextView = findViewById(R.id.textHolerite_Nome);
        TextView descricao_cargoTextView = findViewById(R.id.textHolerite_Cargo);
        TextView valor_pagamentoTextView = findViewById(R.id.textVisualizarSalarioBruto);
        TextView inssTextView = findViewById(R.id.textVisualizarInss);
        TextView irrfTextView = findViewById(R.id.textVisualizarIrrf);
        TextView salarioLiquidoTextView = findViewById((R.id.textVisualizarSalarioLiquido));
        TextView mes_e_anoTextView = findViewById(R.id.textMesEAno);
        TextView eventoTextView = findViewById(R.id.textEvento);
        TextView id_funcionarioTextView = findViewById(R.id.textId_funcionarioHolerite);




        nomeTextView.setText(nomeUsuario);
        descricao_cargoTextView.setText(descricao_cargo);
        valor_pagamentoTextView.setText(salarioFormatado);
        inssTextView.setText(inssFormatado);
        irrfTextView.setText(descontoIrrfFormatado);
        salarioLiquidoTextView.setText(salarioLiquidoFormatado);
        mes_e_anoTextView.setText(String.valueOf(mes_e_ano));
        eventoTextView.setText(evento);
        id_funcionarioTextView.setText("0000" + String.valueOf(id_funcionario));
    }

    public void voltarMenuPrincipalVisualizacaoHolerite(View view) {
        finish();
    }
}
