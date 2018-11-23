package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;
import java.util.List;

public class Device implements Serializable {
    @SerializedName("DeviceId")
    private Integer deviceId;
    @SerializedName("AgencyId")
    private Integer agencyId;
    @SerializedName("AgencyName")
    private String agencyName;
    @SerializedName("DeviceTypeId")
    private Integer deviceTypeId;
    @SerializedName("DeviceTypeName")
    private String deviceTypeName;
    @SerializedName("DeviceName")
    private String deviceName;
    @SerializedName("DeviceCode")
    private String deviceCode;
    @SerializedName("GuarantyStartDate")
    private String guarantyStartDate;
    @SerializedName("GuarantyEndDate")
    private String guarantyEndDate;
    @SerializedName("Ip")
    private String ip;
    @SerializedName("Port")
    private String port;
    @SerializedName("DeviceAccount")
    private String deviceAccount;
    @SerializedName("DevicePassword")
    private String devicePassword;
    @SerializedName("SettingDate")
    private String settingDate;
    @SerializedName("Other")
    private String other;
    @SerializedName("CreateDate")
    private String createDate;
    @SerializedName("UpdateDate")
    private String updateDate;
    @SerializedName("TicketList")
    private List<DeviceHistory_Ticket> ticketList;


    public Integer getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(Integer deviceId) {
        this.deviceId = deviceId;
    }

    public Integer getAgencyId() {
        return agencyId;
    }

    public void setAgencyId(Integer agencyId) {
        this.agencyId = agencyId;
    }

    public Integer getDeviceTypeId() {
        return deviceTypeId;
    }

    public void setDeviceTypeId(Integer deviceTypeId) {
        this.deviceTypeId = deviceTypeId;
    }

    public String getDeviceName() {
        return deviceName;
    }

    public void setDeviceName(String deviceName) {
        this.deviceName = deviceName;
    }

    public String getDeviceCode() {
        return deviceCode;
    }

    public void setDeviceCode(String deviceCode) {
        this.deviceCode = deviceCode;
    }

    public String getGuarantyStartDate() {
        return guarantyStartDate;
    }

    public void setGuarantyStartDate(String guarantyStartDate) {
        this.guarantyStartDate = guarantyStartDate;
    }

    public String getGuarantyEndDate() {
        return guarantyEndDate;
    }

    public void setGuarantyEndDate(String guarantyEndDate) {
        this.guarantyEndDate = guarantyEndDate;
    }

    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public String getPort() {
        return port;
    }

    public void setPort(String port) {
        this.port = port;
    }

    public String getDeviceAccount() {
        return deviceAccount;
    }

    public void setDeviceAccount(String deviceAccount) {
        this.deviceAccount = deviceAccount;
    }

    public String getDevicePassword() {
        return devicePassword;
    }

    public void setDevicePassword(String devicePassword) {
        this.devicePassword = devicePassword;
    }

    public String getSettingDate() {
        return settingDate;
    }

    public void setSettingDate(String settingDate) {
        this.settingDate = settingDate;
    }

    public String getOther() {
        return other;
    }

    public void setOther(String other) {
        this.other = other;
    }

    public String getCreateDate() {
        return createDate;
    }

    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }

    public String getUpdateDate() {
        return updateDate;
    }

    public void setUpdateDate(String updateDate) {
        this.updateDate = updateDate;
    }

    public String getAgencyName() {
        return agencyName;
    }

    public void setAgencyName(String agencyName) {
        this.agencyName = agencyName;
    }

    public String getDeviceTypeName() {
        return deviceTypeName;
    }

    public void setDeviceTypeName(String deviceTypeName) {
        this.deviceTypeName = deviceTypeName;
    }

    public List<DeviceHistory_Ticket> getTicketList() {
        return ticketList;
    }

    public void setTicketList(List<DeviceHistory_Ticket> ticketList) {
        this.ticketList = ticketList;
    }
}
