package com.vitorliberalino.folhasoftjava.model;

public class Descontos {
    private Integer id_descontos;
    private double salario_minimo;
    private double aliquota_inss;
    private double aliquota_irrf;
    private double deducao_irrf;
    private double valor_falta;

    public Integer getId_descontos() {
        return id_descontos;
    }

    public void setId_descontos(Integer id_desconto) {
        this.id_descontos = id_desconto;
    }

    public double getSalario_minimo() {
        return salario_minimo;
    }

    public void setSalario_minimo(double salario_minimo) {
        this.salario_minimo = salario_minimo;
    }

    public double getAliquota_inss() {
        return aliquota_inss;
    }

    public void setAliquota_inss(double aliquota_inss) {
        this.aliquota_inss = aliquota_inss;
    }

    public double getAliquota_irrf() {
        return aliquota_irrf;
    }

    public void setAliquota_irrf(double aliquota_irrf) {
        this.aliquota_irrf = aliquota_irrf;
    }

    public double getDeducao_irrf() {
        return deducao_irrf;
    }

    public void setDeducao_irrf(double deducao_irrf) {
        this.deducao_irrf = deducao_irrf;
    }

    public double getValor_falta() {
        return valor_falta;
    }

    public void setValor_falta(double valor_falta) {
        this.valor_falta = valor_falta;
    }
}
