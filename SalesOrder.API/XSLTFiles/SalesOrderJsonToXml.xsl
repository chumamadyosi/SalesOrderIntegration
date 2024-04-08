<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes"/>

  <!-- Template to match the root element -->
  <xsl:template match="/">
    <SalesOrder>
      <!-- Copy orderRef, orderDate, currency, and other elements from JSON -->
      <xsl:apply-templates select="order"/>
    </SalesOrder>
  </xsl:template>

  <!-- Template to match the order element -->
  <xsl:template match="order">
    <Order>
      <OrderRef>
        <xsl:value-of select="orderRef"/>
      </OrderRef>
      <OrderDate>
        <xsl:value-of select="orderDate"/>
      </OrderDate>
      <!-- Add more elements as needed -->
    </Order>
  </xsl:template>

  <!-- Add more templates as needed for other elements -->
</xsl:stylesheet>
