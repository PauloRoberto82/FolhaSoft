package com.vitorliberalino.folhasoftjava.model;

import java.util.Date;

public class Usuario {
    private Integer codigo;
    private String email;
    private String senha;
    private String nome;
    private Date dataNascimento;
    private String telefone;
    private String cpf;
    private String rg;
    private String sexo;
    private String estadoCivil;
    private String carteiraTrabalho;
    private String nisPis;
    private Date dataAdmissional;
    private Date dataDemissional;





    public Integer getCodigo() {
        return codigo;
    }

    public void setCodigo(Integer codigo) {
        this.codigo = codigo;
    }


    public String getEmail() {
        return email;
    }

    public void setEmail(String usuario) {
        this.email = email;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public Date getDataNascimento() {
        return dataNascimento;
    }

    public void setDataNascimento(Date dataNascimento) { this.dataNascimento = dataNascimento; }

    public String getTelefone() {
        return telefone;
    }

    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }

    public String getRg() {
        return rg;
    }

    public void setRg(String rg) {
        this.rg = rg;
    }

    public String getSexo() {
        return sexo;
    }

    public void setSexo(String sexo) {
        this.sexo = sexo;
    }

    public String getEstadoCivil() {
        return estadoCivil;
    }

    public void setEstadoCivil(String estadoCivil) {
        this.estadoCivil = estadoCivil;
    }

    public String getCarteiraTrabalho() {
        return carteiraTrabalho;
    }

    public void setCarteiraTrabalho(String carteiraTrabalho) {
        this.carteiraTrabalho = carteiraTrabalho;
    }

    public String getNisPis() {
        return nisPis;
    }

    public void setNisPis(String nisPis) {
        this.nisPis = nisPis;
    }

    public Date getDataAdmissional() {
        return dataAdmissional;
    }

    public void setDataAdmissional(Date dataAdmissional) {
        this.dataAdmissional = dataAdmissional;
    }

    public Date getDataDemissional() {
        return dataDemissional;
    }

    public void setDataDemissional(Date dataDemissional) { this.dataDemissional = dataDemissional; }

    //Tabela cargos
    private Integer id_cargos;

    private String descricao_cargo;
    private double salario;
    private int carga_horaria_sem;
    private double teto_salario;
    private double piso_salario;


    public String getDescricao_cargo() {
        return descricao_cargo;
    }

    public void setDescricao_cargo(String descricao_cargo) {
        this.descricao_cargo = descricao_cargo;
    }

    public double getSalario() {
        return salario;
    }

    public void setSalario(double salario) {
        this.salario = salario;
    }

    public int getCarga_horaria_sem() {
        return carga_horaria_sem;
    }

    public void setCarga_horaria_sem(int carga_horaria_sem) {
        this.carga_horaria_sem = carga_horaria_sem;
    }

    public double getTeto_salario() {
        return teto_salario;
    }

    public void setTeto_salario(double teto_salario) {
        this.teto_salario = teto_salario;
    }

    public double getPiso_salario() {
        return piso_salario;
    }

    public void setPiso_salario(double piso_salario) {
        this.piso_salario = piso_salario;
    }

    public Integer getId_cargos() {
        return id_cargos;
    }

    public void setId_cargos(Integer id_cargos) {
        this.id_cargos = id_cargos;
    }
}
