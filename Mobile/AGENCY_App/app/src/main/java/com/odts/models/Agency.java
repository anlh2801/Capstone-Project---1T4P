package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class Agency {
    @SerializedName("AgencyId")
    private Integer agencyId;
    @SerializedName("AgencyName")
    private String agencyName;
    @SerializedName("Telephone")
    private String telephone;
    @SerializedName("Address")
    private String Address;
    @SerializedName("CompanyName")
    private String companyName;
    @SerializedName("AccountId")
    private Integer accountId;
    @SerializedName("UserName")
    private String userName;

    @SerializedName("password")
    private String password;

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getTelephone() {
        return telephone;
    }

    public void setTelephone(String telephone) {
        this.telephone = telephone;
    }

    public String getCompanyName() {
        return companyName;
    }

    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public Agency() {

    }

    public Integer getAgencyId() {
        return agencyId;
    }

    public void setAgencyId(Integer agencyId) {
        this.agencyId = agencyId;
    }

    public Integer getAccountId() {
        return accountId;
    }

    public void setAccountId(Integer accountId) {
        this.accountId = accountId;
    }

    public Agency(Integer agencyId, Integer accountId) {

        this.agencyId = agencyId;
        this.accountId = accountId;
    }

    public String getAgencyName() {
        return agencyName;
    }

    public void setAgencyName(String agencyName) {
        this.agencyName = agencyName;
    }

    public String getAddress() {
        return Address;
    }

    public void setAddress(String address) {
        Address = address;
    }
}
