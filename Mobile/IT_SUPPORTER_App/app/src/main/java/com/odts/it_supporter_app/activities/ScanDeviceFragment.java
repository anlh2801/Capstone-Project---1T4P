package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.util.SparseArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.google.android.gms.vision.barcode.Barcode;
import com.odts.it_supporter_app.R;

import java.util.List;

import info.androidhive.barcode.BarcodeReader;


public class ScanDeviceFragment extends Fragment implements BarcodeReader.BarcodeReaderListener {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_scan_device, container, false);
        return v;
    }

    @Override
    public void onScanned(Barcode barcode) {
        // single barcode scanned
    }

    @Override
    public void onScannedMultiple(List<Barcode> list) {
        // multiple barcodes scanned
    }

    @Override
    public void onBitmapScanned(SparseArray<Barcode> sparseArray) {
        // barcode scanned from bitmap image
    }

    @Override
    public void onScanError(String s) {
        // scan error
    }


}
