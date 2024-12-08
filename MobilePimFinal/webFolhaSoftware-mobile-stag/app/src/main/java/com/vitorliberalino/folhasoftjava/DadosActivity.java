package com.vitorliberalino.folhasoftjava;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class DadosActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dados);


        Intent intent = getIntent();
        String emailUsuario = intent.getStringExtra("EMAIL_EXTRA");
        String nomeUsuario = intent.getStringExtra("NOME_EXTRA");
        String telefone = intent.getStringExtra("TELEFONE_EXTRA");
        String cpf = intent.getStringExtra("CPF_EXTRA");
        String rg = intent.getStringExtra("RG_EXTRA");
        String sexo = intent.getStringExtra("SEXO_EXTRA");
        String estadoCivil = intent.getStringExtra("ESTADOCIVIL_EXTRA");
        String carteiraTrabalho = intent.getStringExtra("CARTEIRATRABALHO_EXTRA");
        String nisPis = intent.getStringExtra("NISPIS_EXTRA");
        Integer id_cargos = intent.getIntExtra("IDCARGOS_EXTRA", -1);
        String descricao_cargo = intent.getStringExtra("DESCRICAOCARGO_EXTRA");
        double salario = intent.getDoubleExtra("SALARIO_EXTRA", -1);




        long dataNascimentoComoLong = getIntent().getLongExtra("DATANASCIMENTO_EXTRA", -1);

        if(dataNascimentoComoLong != -1){
            Date dataRecebida = new Date(dataNascimentoComoLong);

            SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
            String dataComoString = formato.format(dataRecebida);
            TextView dataNascimento = findViewById(R.id.textDados_DataNascimento);
            dataNascimento.setText(dataComoString);
        }

        long dataAdmissionalComoLong = getIntent().getLongExtra("DATAADMISSIONAL_EXTRA", -1);

        if(dataAdmissionalComoLong != -1){
            Date dataRecebida = new Date(dataAdmissionalComoLong);

            SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
            String dataComoString = formato.format(dataRecebida);
            TextView dataAdmissional = findViewById(R.id.textDados_DataAdmissional);
            dataAdmissional.setText(dataComoString);
        }

        long dataDemissionalComoLong = getIntent().getLongExtra("DATADEMISSIONAL_EXTRA", -1);

        if(dataDemissionalComoLong == 0){
            TextView dataDemissional = findViewById(R.id.textDados_DataDemisional);
            dataDemissional.setText("");
        }

        else if(dataDemissionalComoLong != -1){
            Date dataRecebida = new Date(dataDemissionalComoLong);

            SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy", Locale.getDefault());
            String dataComoString = formato.format(dataRecebida);
            TextView dataDemissional = findViewById(R.id.textDados_DataDemisional);
            dataDemissional.setText(dataComoString);
        }



        TextView nomeTextView = findViewById(R.id.textDados_Nome);
        TextView emailTextView = findViewById(R.id.textDados_Email);
        TextView telefoneTextView = findViewById(R.id.textDados_Telefone);
        TextView cpfTextView = findViewById(R.id.textDados_Cpf);
        TextView rgTextView = findViewById(R.id.textDados_Rg);
        TextView sexoTextView = findViewById(R.id.textDados_Sexo);
        TextView estadoCivilTextView = findViewById(R.id.textDados_EstadoCivil);
        TextView carteiraTrabalhoTextView = findViewById(R.id.textDados_CarteiraTrabalho);
        TextView nisPisTextView = findViewById(R.id.textDados_NisPis);
        TextView descricao_cargoTextView = findViewById(R.id.textDados_Cargo);



        nomeTextView.setText(nomeUsuario);
        emailTextView.setText(emailUsuario);
        telefoneTextView.setText(telefone);
        cpfTextView.setText(cpf);
        rgTextView.setText(rg);
        sexoTextView.setText(sexo);
        estadoCivilTextView.setText(estadoCivil);
        carteiraTrabalhoTextView.setText(carteiraTrabalho);
        nisPisTextView.setText(nisPis);
        descricao_cargoTextView.setText(descricao_cargo);



    }

    public void voltarMenuPrincipalI(View view) {
        finish();
    }
}