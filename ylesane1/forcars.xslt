<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes" encoding="utf-8"/>

    <xsl:template match="/">


      1. Вывести все имена
      <table border="1">
        <xsl:attribute name="style">border-collapse: collapse;</xsl:attribute>
        <tr>
          <th>Имя</th>
        </tr>
        <xsl:for-each select="//kasutaja">
          <tr>
            <td>
              <xsl:value-of select="nimi"/>
            </td>
          </tr>
        </xsl:for-each>
      </table>
      <br/>
      <br/>

      2. Вывести все Данные
      <table border="1">
        <xsl:attribute name="style">border-collapse: collapse;</xsl:attribute>
        <tr>
          <th>Имя</th>
          <th>Номер телефона</th>
          <th>Услуга</th>
          <th>Оплачено</th>
          <th>Дата приема</th>
        </tr>
        <xsl:for-each select="//kasutaja">
          <tr>
            <td>
              <xsl:value-of select="nimi"/>
            </td>
            <td>
              <xsl:value-of select="telefoninr"/>
            </td>
            <td>
              <xsl:value-of select="teenus/nimetus"/>
            </td>
            <td>
              <xsl:value-of select="teenus/makstud"/>
            </td>
            <td>
              <xsl:value-of select="teenus/kellaaeg"/>
            </td>
          </tr>
        </xsl:for-each>
      </table>
      <br/>
      <br/>

      2. Вывести все имена, у кого мин 2 ребенка
      <table border="1">
        <xsl:attribute name="style">border-collapse: collapse;</xsl:attribute>
        <xsl:for-each select="//inimene[lapsed]">
          <xsl:if test="count(lapsed/inimene)>1">
            <li>
              <xsl:value-of select="nimi"/>
              <xsl:value-of select="count(lapsed/inimene)"/>
            </li>
          </xsl:if>
        </xsl:for-each>
      </table>
      
      <br/>
      <br/>

      5. Указать в таблице у каждого человека прородителя
      <table border="1">
        <xsl:attribute name="style">border-collapse: collapse;</xsl:attribute>
        <tr>
          <th>Прородитель</th>
        </tr>
        <xsl:for-each select="//inimene">
          <tr>
            <td>
              <xsl:value-of select="../../nimi"/>
            </td>
            <td>
              <xsl:value-of select="nimi"/>
            </td>
            <td>
              <xsl:value-of select="synnaaasta"/>
            </td>
            <td>
              <xsl:value-of select="2019-synnaaasta"/>
            </td>
            <td>
              <xsl:value-of select="../../nimi"/>
            </td>
          </tr>
        </xsl:for-each>
      </table>
      
      <br/>
      <br/>
      3. Вывести родословеную в виде таблицы
      <br/>
      4. Указать в таблице у каждого человека родителя
      <br/>
      6. Выводить в  таблице возраст каждого ребенка
      <br/>
      7. Вывести около каждого человека в каком году он родился у своего родителя
      <br/>
      <table border="1">
        <xsl:attribute name="style">border-collapse: collapse;</xsl:attribute>
        <tr>
          <th>Vanem</th>
          <th>Laps</th>
          <th>Sunniaasta</th>
          <th>Возраст каждого ребенка</th>
          <th>Прородителя</th>
        </tr>
        <xsl:for-each select="//inimene">
          <tr>
            <td>
              <xsl:value-of select="../../nimi"/>
            </td>
            <td>
              <xsl:value-of select="nimi"/>
            </td>
            <td>
              <xsl:value-of select="synnaaasta"/>
            </td>
            <td>
              <xsl:value-of select="2019-synnaaasta"/>
            </td>
            <td>
              <xsl:value-of select="../../nimi"/>
            </td>
          </tr>
        </xsl:for-each>
      </table>
      <br/>
      <br/>

      
      
    </xsl:template>
</xsl:stylesheet>
