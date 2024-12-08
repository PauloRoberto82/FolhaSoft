package com.vitorliberalino.folhasoftjava;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.content.Intent;
import android.widget.Toast;
import android.os.Handler;
import android.widget.ProgressBar;
import android.view.Gravity;
import java.util.Date;


import com.google.android.material.textfield.TextInputEditText;
import com.vitorliberalino.folhasoftjava.dao.UsuarioDAO;
import com.vitorliberalino.folhasoftjava.model.Usuario;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button loginButton = findViewById(R.id.Login);
        ProgressBar progressBar = findViewById(R.id.progressBar);
        TextInputEditText email = findViewById(R.id.login_email);
        TextInputEditText senha = findViewById(R.id.login_senha);



        loginButton.setOnClickListener(v ->
        {
            String emailUsuario = email.getText().toString();
            String senhaUsuario = senha.getText().toString();
            System.out.println("Email recebido: " + emailUsuario);
            System.out.println("Senha recebido: " + senhaUsuario);

            Usuario usu = new UsuarioDAO().selecionaUsuario(emailUsuario, senhaUsuario);

            if(usu != null){
                Toast toast = Toast.makeText(MainActivity.this, "Login bem-sucedido!", Toast.LENGTH_SHORT);
                toast.setGravity(Gravity.CENTER, 0, 700);
                toast.show();

                // Mostra o ProgressBar
                progressBar.setVisibility(View.VISIBLE);

                new Handler().postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        // Esconde o ProgressBar
                        progressBar.setVisibility(View.GONE);

                        // Navega para a próxima tela
                        Intent intent = new Intent(MainActivity.this, MenuPrincipalActivity.class);
                        intent.putExtra("IDFUNCIONARIO_EXTRA", usu.getCodigo());
                        intent.putExtra("EMAIL_EXTRA", emailUsuario);
                        intent.putExtra("NOME_EXTRA", usu.getNome());
                        intent.putExtra("TELEFONE_EXTRA", usu.getTelefone());
                        intent.putExtra("CPF_EXTRA", usu.getCpf());
                        intent.putExtra("RG_EXTRA", usu.getRg());
                        intent.putExtra("SEXO_EXTRA", usu.getSexo());
                        intent.putExtra("ESTADOCIVIL_EXTRA", usu.getEstadoCivil());
                        intent.putExtra("CARTEIRATRABALHO_EXTRA", usu.getCarteiraTrabalho());
                        intent.putExtra("NISPIS_EXTRA", usu.getNisPis());
                        intent.putExtra("IDCARGOS_EXTRA", usu.getId_cargos());
                        intent.putExtra("DESCRICAOCARGO_EXTRA", usu.getDescricao_cargo());
                        intent.putExtra("SALARIO_EXTRA", usu.getSalario());



                        Date dataNascimento = usu.getDataNascimento();
                        long dataNascimentoComoLong = dataNascimento.getTime();
                        intent.putExtra("DATANASCIMENTO_EXTRA", dataNascimentoComoLong);

                        Date dataAdmissional = usu.getDataAdmissional();
                        long dataAdmissionalComoLong = dataAdmissional.getTime();
                        intent.putExtra("DATAADMISSIONAL_EXTRA", dataAdmissionalComoLong);

                        Date dataDemissional = usu.getDataDemissional();
                        if(dataDemissional == null){
                            long dataDemissionalComoLong = 0;
                            intent.putExtra("DATADEMISSIONAL_EXTRA", dataDemissionalComoLong);

                            startActivity(intent);
                        }
                        else{
                        long dataDemissionalComoLong = dataDemissional.getTime();
                        intent.putExtra("DATADEMISSIONAL_EXTRA", dataDemissionalComoLong);

                        startActivity(intent);}

                        }
                }, 2000);} else {
                Toast toast = Toast.makeText(MainActivity.this, "Email ou senha incorretos", Toast.LENGTH_SHORT);
                toast.setGravity(Gravity.CENTER, 0, 700);
                toast.show();



            }

            /*if(emailUsuario.equals("jvitorliberalino@gmail.com") && senhaUsuario.equals("24072001Vi.")){
            Toast toast = Toast.makeText(MainActivity.this, "Login bem-sucedido!", Toast.LENGTH_SHORT);
            toast.setGravity(Gravity.CENTER, 0, 700);
            toast.show();

            // Mostra o ProgressBar
            progressBar.setVisibility(View.VISIBLE);

            new Handler().postDelayed(new Runnable() {
                @Override
                public void run() {
                    // Esconde o ProgressBar
                    progressBar.setVisibility(View.GONE);

                    // Navega para a próxima tela
                    Intent intent = new Intent(MainActivity.this, MenuPrincipalActivity.class);
                    startActivity(intent);
                }
            }, 2000);}
            else {
                Toast toast = Toast.makeText(MainActivity.this, "Email ou senha incorretos", Toast.LENGTH_SHORT);
                toast.setGravity(Gravity.CENTER, 0, 700);
                toast.show();
            }*/

        });





    }


    public void esqueciSenha(View view) {
        Intent intent = new Intent(MainActivity.this, RecuperacaoActivity.class);
        startActivity(intent);
    }



}