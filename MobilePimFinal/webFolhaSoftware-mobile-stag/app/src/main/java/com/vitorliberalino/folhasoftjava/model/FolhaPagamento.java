package com.vitorliberalino.folhasoftjava.model;
import java.util.Date;

public class FolhaPagamento {
    private Integer id_pagamento;
    private Integer id_cargos;
    private Integer id_descontos;
    private Date data_pagamento;
    private Integer id_funcionario;
    private String descricao_evento;
    private double valor_pagamento;
    private int faltas;


    public Integer getId_pagamento() {
        return id_pagamento;
    }

    public void setId_pagamento(Integer id_pagamento) {
        this.id_pagamento = id_pagamento;
    }

    public Integer getId_cargos() {
        return id_cargos;
    }

    public void setId_cargos(Integer id_cargos) {
        this.id_cargos = id_cargos;
    }

    public Integer getId_descontos() {
        return id_descontos;
    }

    public void setId_descontos(Integer id_descontos) {
        this.id_descontos = id_descontos;
    }

    public Date getData_pagamento() {
        return data_pagamento;
    }

    public void setData_pagamento(Date data_pagamento) {
        this.data_pagamento = data_pagamento;
    }

    public Integer getId_funcionario() {
        return id_funcionario;
    }

    public void setId_funcionario(Integer id_funcionario) {
        this.id_funcionario = id_funcionario;
    }

    public String getDescricao_evento() {
        return descricao_evento;
    }

    public void setDescricao_evento(String descricao_evento) {
        this.descricao_evento = descricao_evento;
    }

    public double getValor_pagamento() {
        return valor_pagamento;
    }

    public void setValor_pagamento(double valor_pagamento) {
        this.valor_pagamento = valor_pagamento;
    }

    public int getFaltas() {
        return faltas;
    }

    public void setFaltas(int faltas) {
        this.faltas = faltas;
    }
}
