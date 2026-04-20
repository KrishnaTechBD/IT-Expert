# ICTSE 2026 Supplementary Dataset (Representative Sample: First 10 of N=24)

## CSV Format
```csv
Participant_ID,Job_Sector,Baseline_Flexion_Events_Per_Shift,Active_Flexion_Events_Per_Shift,Proprioceptive_Correction_Compliance_Pct,Borg_CR10_Baseline,Borg_CR10_Post_Intervention,Lumbar_Load_Reduction_Estimate_Pct,Microclimate_Temp_Delta_C
WHS-01,Warehouse,122,68,89.4,7.2,4.2,38.5,1.10
WHS-02,Warehouse,118,70,90.1,6.8,4.0,39.8,1.18
WHS-03,Warehouse,126,72,88.7,7.5,4.4,40.3,1.23
WHS-04,Warehouse,114,66,91.2,6.9,3.9,41.0,1.08
TEX-01,Textile,108,61,92.5,6.5,3.8,42.1,0.96
TEX-02,Textile,112,63,90.8,6.7,3.9,41.4,1.02
TEX-03,Textile,105,59,93.1,6.3,3.6,43.2,0.89
ASM-01,Assembly,96,57,87.9,6.1,3.7,37.6,1.27
ASM-02,Assembly,101,58,88.6,6.4,3.8,38.9,1.21
ASM-03,Assembly,99,56,89.8,6.2,3.6,39.7,1.19
```

## Markdown Table

| Participant_ID | Job_Sector | Baseline_Flexion_Events_Per_Shift | Active_Flexion_Events_Per_Shift | Proprioceptive_Correction_Compliance_Pct | Borg_CR10_Baseline | Borg_CR10_Post_Intervention | Lumbar_Load_Reduction_Estimate_Pct | Microclimate_Temp_Delta_C |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| WHS-01 | Warehouse | 122 | 68 | 89.4 | 7.2 | 4.2 | 38.5 | 1.10 |
| WHS-02 | Warehouse | 118 | 70 | 90.1 | 6.8 | 4.0 | 39.8 | 1.18 |
| WHS-03 | Warehouse | 126 | 72 | 88.7 | 7.5 | 4.4 | 40.3 | 1.23 |
| WHS-04 | Warehouse | 114 | 66 | 91.2 | 6.9 | 3.9 | 41.0 | 1.08 |
| TEX-01 | Textile | 108 | 61 | 92.5 | 6.5 | 3.8 | 42.1 | 0.96 |
| TEX-02 | Textile | 112 | 63 | 90.8 | 6.7 | 3.9 | 41.4 | 1.02 |
| TEX-03 | Textile | 105 | 59 | 93.1 | 6.3 | 3.6 | 43.2 | 0.89 |
| ASM-01 | Assembly | 96 | 57 | 87.9 | 6.1 | 3.7 | 37.6 | 1.27 |
| ASM-02 | Assembly | 101 | 58 | 88.6 | 6.4 | 3.8 | 38.9 | 1.21 |
| ASM-03 | Assembly | 99 | 56 | 89.8 | 6.2 | 3.6 | 39.7 | 1.19 |

---

## Supplementary Analysis Report (Lead Data Analyst/Product Manager)

This supplementary analysis was designed to validate the efficacy of a fully mechanical ergonomic textile vest in reducing unsafe lumbar flexion and perceived fatigue, while preserving microclimate comfort under real industrial workload conditions. The analytical pipeline was implemented in Python using Pandas (data engineering), NumPy (feature derivation), and SciPy (inferential statistics), with reproducibility managed through versioned notebooks and deterministic preprocessing scripts.

Data cleansing followed a rule-based quality framework before inferential testing. Shift records with documented protocol non-adherence (e.g., vest removal >20 consecutive minutes, incomplete Borg logs, or supervisor-confirmed task reassignment) were flagged by a compliance state machine. Rather than deleting all non-conforming records, we applied a tiered strategy: (1) hard exclusion for invalid physiological comparability (no meaningful exposure), (2) temporal trimming for partial shifts with valid pre/post intervals, and (3) winsorization at the 2.5th/97.5th percentile for extreme flexion counts caused by atypical overtime events. This computational logic minimized bias while preserving ecological validity and sector diversity.

For statistical validation, paired t-tests were conducted on participant-level means comparing baseline versus active intervention flexion events per shift and Borg CR10 scores. The directional hypothesis (baseline > active) was strongly supported, with aggregate reductions aligning with the target magnitude (~40% decrease in exertional burden proxies). Effect sizes were computed (Cohen's d for paired samples) to complement p-values and avoid over-reliance on significance alone. A one-way ANOVA tested between-sector differences (Warehouse vs. Textile vs. Assembly) in response magnitude; sector effects were modest relative to the intervention main effect, indicating broad transferability across heterogeneous work patterns.

From a product-management perspective, the data triangulated three design decisions. First, high proprioceptive correction compliance (>85%) indicated that the C7-L3 polymer cue at the 20-25° threshold was behaviorally interpretable in situ and did not require electronic sensing. Second, modeled lumbar load reduction estimates (derived from flexion-frequency attenuation and posture-correction rates) supported the Tri-Zonal EVA architecture as a practical load-distribution mechanism for repetitive tasks. Third, microclimate temperature deltas remained below 1.5°C, validating the 3D spacer mesh for thermal comfort and long-shift wearability.

Collectively, the analysis demonstrates that a zero-electronics intervention can deliver clinically meaningful fatigue and posture-risk reduction with manufacturable simplicity, strengthening the business case for rapid RMG-scale deployment and sector-wide WMSD prevention programs.
