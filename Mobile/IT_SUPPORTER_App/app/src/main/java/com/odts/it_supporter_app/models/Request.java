package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Request {

    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("AgencyId")
    private Integer agencyId;

    @SerializedName("AgencyName")
    private String agencyName;

    @SerializedName("ServiceId")
    private Integer serviceId;

    @SerializedName("RequestCategoryId")
    private Integer requestCategoryId;

    @SerializedName("ServiceItemId")
    private Integer serviceItemId;

    @SerializedName("ServiceItemName")
    private String serviceItemName;

    @SerializedName("RequestName")
    private String requestName;

    @SerializedName("RequestDesciption")
    private String RequestDesciption;

    @SerializedName("AgencyTelephone")
    private String phoneNumber;

    @SerializedName("CreateDate")
    private String createDate;

    @SerializedName("UpdateDate")
    private String updateDate;

    @SerializedName("StartTime")
    private String startTime;

    @SerializedName("EndTime")
    private String endTime;

    @SerializedName("RequestStatus")
    private String status;

    @SerializedName("RequestEstimationTime")
    private String requestEstimationTime;

    @SerializedName("NumberOfTicket")
    private Integer nod;

    @SerializedName("ITSupporterName")
    private String iTSupporterName;

    @SerializedName("Tickets")
    private List<Ticket> ticket;

    @SerializedName("AgencyAddress")
    private String agencyAddress;

    @SerializedName("FeedBack")
    private  String feedBack;

    @SerializedName("Rating")
    private  Integer Rating;

    @SerializedName("Priority")
    private  String priority;

    public Integer getServiceId() {
        return serviceId;
    }

    public void setServiceId(Integer serviceId) {
        this.serviceId = serviceId;
    }

    public String getPriority() {
        return priority;
    }

    public void setPriority(String priority) {
        this.priority = priority;
    }

    public Integer getRating() {
        return Rating;
    }

    public void setRating(Integer rating) {
        Rating = rating;
    }

    public String getFeedBack() {
        return feedBack;
    }

    public void setFeedBack(String feedBack) {
        this.feedBack = feedBack;
    }

    public String getAgencyAddress() {
        return agencyAddress;
    }

    public void setAgencyAddress(String agencyAddress) {
        this.agencyAddress = agencyAddress;
    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public Integer getAgencyId() {
        return agencyId;
    }

    public void setAgencyId(Integer agencyId) {
        this.agencyId = agencyId;
    }

    public String getAgencyName() {
        return agencyName;
    }

    public void setAgencyName(String agencyName) {
        this.agencyName = agencyName;
    }

    public Integer getRequestCategoryId() {
        return requestCategoryId;
    }

    public void setRequestCategoryId(Integer requestCategoryId) {
        this.requestCategoryId = requestCategoryId;
    }

    public Integer getServiceItemId() {
        return serviceItemId;
    }

    public void setServiceItemId(Integer serviceItemId) {
        this.serviceItemId = serviceItemId;
    }

    public String getRequestName() {
        return requestName;
    }

    public void setRequestName(String requestName) {
        this.requestName = requestName;
    }

    public String getRequestDesciption() {
        return RequestDesciption;
    }

    public void setRequestDesciption(String requestDesciption) {
        RequestDesciption = requestDesciption;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
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

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getRequestEstimationTime() {
        return requestEstimationTime;
    }

    public void setRequestEstimationTime(String requestEstimationTime) {
        this.requestEstimationTime = requestEstimationTime;
    }

    public Integer getNod() {
        return nod;
    }

    public void setNod(Integer nod) {
        this.nod = nod;
    }

    public String getiTSupporterName() {
        return iTSupporterName;
    }

    public void setiTSupporterName(String iTSupporterName) {
        this.iTSupporterName = iTSupporterName;
    }

    public List<Ticket> getTicket() {
        return ticket;
    }

    public void setTicket(List<Ticket> ticket) {
        this.ticket = ticket;
    }

    public Request() {
    }

    public String getServiceItemName() {
        return serviceItemName;
    }

    public void setServiceItemName(String serviceItemName) {
        this.serviceItemName = serviceItemName;
    }

    public String getStartTime() {
        return startTime;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }
}
