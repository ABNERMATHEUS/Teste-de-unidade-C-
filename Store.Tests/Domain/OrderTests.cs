using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{   
    [TestClass] 
    public class OrderTests
    {
        
        private readonly Customer _customer = new Customer("Abner matheus", "abnerm80@gmail.com");
        private readonly Product _product = new Product("Product 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

        [TestMethod] //Metodo teste
        [TestCategory("Domain")] //Apenas categorizar os testes
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres() //nomes dos testes
        {

            var order = new Order(_customer, 0, null);
            
            Assert.AreEqual(8, order.Number.Length);  //Se 8 == a quantidade de números =  teste válido
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento_()
        {
            var order = new Order(_customer, 0, null); //ordem de compra
            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status); // se a ordem tiver um status esperando pagamento então válido
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_pedido_seu_status_deve_mudar_para_aguardando_entrega()
        {
            var order = new Order(_customer,0, null);//ordem de compra
            order.AddItem(_product, 1);//adicionar um item no carrinho
            order.Pay(10); ///vai pagar 
            Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_cancelamento_pedido_seu_status_deve_mudar_para_cancelado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 1);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(null,10 ); //Se eu colocar nenhum produto e colocar 10 quantidades
            Assert.AreEqual(order.Items.Count, 0);//ele deve retornar 0
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 0);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
            public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5));
            var order = new Order(_customer, 10, expiredDiscount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }



        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.AreEqual(order.Total(), 50);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 6);
            Assert.AreEqual(order.Total(), 60);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var order = new Order(null, 10, _discount);
            Assert.AreEqual(order.Valid, false);
        }


    }
}
