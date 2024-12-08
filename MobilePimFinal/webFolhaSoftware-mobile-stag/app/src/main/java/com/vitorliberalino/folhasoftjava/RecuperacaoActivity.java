package com.vitorliberalino.folhasoftjava;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.Toast;

public class RecuperacaoActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recuperacao);

    }

    public void enviarLink(View view) {
        Toast toast = Toast.makeText(RecuperacaoActivity.this, "Link enviado com sucesso!!", Toast.LENGTH_SHORT);
        toast.setGravity(Gravity.CENTER, 0, 700);
        toast.show();
    }

    public void VoltardoEsqueceu(View view) {
        Intent intent = new Intent(RecuperacaoActivity.this, MainActivity.class);
        startActivity(intent);
    }
}