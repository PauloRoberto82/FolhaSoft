package com.vitorliberalino.folhasoftjava;


import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;
import android.view.View;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class MenuPrincipalActivity extends AppCompatActivity {

    private String emailUsuario;
    private String nomeUsuario;
    private long dataNascimentoComoLong;
    private String telefone;
    private String cpf;
    private String rg;
    private String sexo;
    private String estadoCivil;
    private String carteiraTrabalho;
    private String nisPis;
    private long dataAdmissionalComoLong;
    private long dataDemissionalComoLong;
    private Integer id_cargos;
    private String descricao_cargo;
    private double salario;
    private Integer id_funcionario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.menuprincipal);

        Intent intent = getIntent();
        id_funcionario = intent.getIntExtra("IDFUNCIONARIO_EXTRA", -1);
        emailUsuario = intent.getStringExtra("EMAIL_EXTRA");
        nomeUsuario = intent.getStringExtra("NOME_EXTRA");
        dataNascimentoComoLong = getIntent().getLongExtra("DATANASCIMENTO_EXTRA", - 1);
        telefone = intent.getStringExtra("TELEFONE_EXTRA");
        cpf = intent.getStringExtra("CPF_EXTRA");
        rg = intent.getStringExtra("RG_EXTRA");
        sexo = intent.getStringExtra("SEXO_EXTRA");
        estadoCivil = intent.getStringExtra("ESTADOCIVIL_EXTRA");
        carteiraTrabalho = intent.getStringExtra("CARTEIRATRABALHO_EXTRA");
        nisPis = intent.getStringExtra("NISPIS_EXTRA");
        dataAdmissionalComoLong = getIntent().getLongExtra("DATAADMISSIONAL_EXTRA", - 1);
        dataDemissionalComoLong = getIntent().getLongExtra("DATADEMISSIONAL_EXTRA", - 1);
        id_cargos = intent.getIntExtra("IDCARGOS_EXTRA", -1);
        descricao_cargo = intent.getStringExtra("DESCRICAOCARGO_EXTRA");
        salario = intent.getDoubleExtra("SALARIO_EXTRA", -1);




        TextView emailTextView = findViewById(R.id.emailUsuario);
        TextView nomeTextView = findViewById(R.id.nomeColaborador);

        emailTextView.setText(emailUsuario);
        nomeTextView.setText(nomeUsuario);

    }


    public void Holerite(View view) {
        Intent intent = new Intent(MenuPrincipalActivity.this, HoleriteActivity.class);
        intent.putExtra("IDFUNCIONARIO_EXTRA", id_funcionario);
        intent.putExtra("NOME_EXTRA", nomeUsuario);
        intent.putExtra("DESCRICAOCARGO_EXTRA", descricao_cargo);
        startActivity(intent);
    }

    public void Avisos(View view) {
        Intent intent = new Intent(MenuPrincipalActivity.this, AvisosActivity.class);
        startActivity(intent);
    }

    public void Dados(View view) {
        Intent intent = new Intent(MenuPrincipalActivity.this, DadosActivity.class);
        intent.putExtra("EMAIL_EXTRA", emailUsuario);
        intent.putExtra("NOME_EXTRA", nomeUsuario);
        intent.putExtra("DATANASCIMENTO_EXTRA", dataNascimentoComoLong);
        intent.putExtra("TELEFONE_EXTRA", telefone);
        intent.putExtra("CPF_EXTRA", cpf);
        intent.putExtra("RG_EXTRA", rg);
        intent.putExtra("SEXO_EXTRA", sexo);
        intent.putExtra("ESTADOCIVIL_EXTRA", estadoCivil);
        intent.putExtra("CARTEIRATRABALHO_EXTRA", carteiraTrabalho);
        intent.putExtra("NISPIS_EXTRA", nisPis);
        intent.putExtra("DATAADMISSIONAL_EXTRA", dataAdmissionalComoLong);
        intent.putExtra("DATADEMISSIONAL_EXTRA", dataDemissionalComoLong);
        intent.putExtra("IDCARGOS_EXTRA", id_cargos);
        intent.putExtra("DESCRICAOCARGO_EXTRA", descricao_cargo);
        intent.putExtra("SALARIO_EXTRA", salario);
        startActivity(intent);
    }

    public void FaleComRh(View view) {
        Intent intent = new Intent(MenuPrincipalActivity.this, FaleRhActivity.class);
        startActivity(intent);
    }

    public void Voltar(View view) {
        Intent intent = new Intent(MenuPrincipalActivity.this, MainActivity.class);
        startActivity(intent);
    }




}