package com.vitorliberalino.folhasoftjava.dao;

import android.util.Log;

import com.vitorliberalino.folhasoftjava.conexao.Conexao;
import com.vitorliberalino.folhasoftjava.model.Descontos;
import com.vitorliberalino.folhasoftjava.model.FolhaPagamento;
import com.vitorliberalino.folhasoftjava.model.Usuario;


import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class UsuarioDAO {

    public Usuario selecionaUsuario(String usuario, String senha){
        try {
            Connection conn = Conexao.conectar();
            if(conn != null){
                String sql = "select * from funcionario " + "JOIN cargos ON funcionario.id_cargos = cargos.id_cargos " + "where email = '" +usuario+"' and senha = '"+senha+"'";
                Statement st = null;
                st = conn.createStatement();

                ResultSet rs = st.executeQuery(sql);
                while(rs.next()){
                    Usuario usu = new Usuario();
                    usu.setCodigo(rs.getInt("id_funcionario"));
                    usu.setEmail(rs.getString("email"));
                    usu.setSenha(rs.getString("senha"));
                    usu.setNome(rs.getString("nome"));
                    usu.setDataNascimento(rs.getDate("data_nasc"));
                    usu.setTelefone(rs.getString("telefone"));
                    usu.setCpf(rs.getString("cpf"));
                    usu.setRg(rs.getString("rg"));
                    usu.setSexo(rs.getString("sexo"));
                    usu.setEstadoCivil(rs.getString("estado_civil"));
                    usu.setCarteiraTrabalho(rs.getString("carteira_trabalho"));
                    usu.setNisPis(rs.getString("nis_pis"));
                    usu.setDataAdmissional(rs.getDate("data_admissional"));
                    usu.setDataDemissional(rs.getDate("data_demissional"));

                    usu.setId_cargos(rs.getInt("id_cargos"));
                    usu.setDescricao_cargo(rs.getString("descricao_cargo"));
                    usu.setSalario(rs.getDouble("salario"));



                    


                    conn.close();
                    return usu;
                }

            }

        } catch (ClassNotFoundException | SQLException e ) {
            e.printStackTrace();
            Log.e("Erro Aula", e.getMessage());
            e.printStackTrace();
            System.out.println("Erro: " + e);
        }

        return null;
        }

    public FolhaPagamento buscarFolha(int idFuncionario, int mes, int ano){
        try {
            Connection conn = Conexao.conectar();
            if(conn != null){
                String sql = "select * from folha_pagamento " + "JOIN descontos ON folha_pagamento.id_descontos = descontos.id_descontos " + "where YEAR(data_pagamento) = " +ano+" and MONTH(data_pagamento) = "+mes+
                        " AND id_funcionario = "+idFuncionario+ ";";
                Statement st = null;
                st = conn.createStatement();

                ResultSet rs = st.executeQuery(sql);
                while(rs.next()){
                    FolhaPagamento folhapagamento = new FolhaPagamento();
                    folhapagamento.setId_pagamento(rs.getInt("id_pagamento"));
                    folhapagamento.setId_cargos(rs.getInt("id_cargos"));
                    folhapagamento.setId_descontos(rs.getInt("id_descontos"));
                    folhapagamento.setData_pagamento(rs.getDate("data_pagamento"));
                    folhapagamento.setId_funcionario(rs.getInt("id_funcionario"));
                    folhapagamento.setDescricao_evento(rs.getString("descricao_evento"));
                    folhapagamento.setValor_pagamento(rs.getDouble("valor_pagamento"));
                    folhapagamento.setFaltas(rs.getInt("faltas"));








                    conn.close();
                    return folhapagamento;
                }
                conn.close();
                return null;

            }

        } catch (ClassNotFoundException | SQLException e ) {
            e.printStackTrace();
            Log.e("Erro Aula", e.getMessage());
            e.printStackTrace();
            System.out.println("Erro: " + e);
        }

        return null;
    }

    public Descontos buscarDescontos(){
        try {
            Connection conn = Conexao.conectar();
            if(conn != null){
                String sql = "select * from descontos ";
                Statement st = null;
                st = conn.createStatement();

                ResultSet rs = st.executeQuery(sql);
                while(rs.next()){
                    Descontos descontos = new Descontos();
                    descontos.setId_descontos(rs.getInt("id_descontos"));
                    descontos.setSalario_minimo(rs.getDouble("salario_minimo"));
                    descontos.setAliquota_inss(rs.getDouble("aliquota_inss"));
                    descontos.setAliquota_irrf(rs.getDouble("aliquota_irrf"));
                    descontos.setDeducao_irrf(rs.getDouble("deducao_irrf"));
                    descontos.setValor_falta(rs.getDouble("valor_falta"));

                    conn.close();
                    return descontos;
                }

            }

        } catch (ClassNotFoundException | SQLException e ) {
            e.printStackTrace();
            Log.e("Erro Aula", e.getMessage());
            e.printStackTrace();
            System.out.println("Erro: " + e);
        }

        return null;
    }
    }

